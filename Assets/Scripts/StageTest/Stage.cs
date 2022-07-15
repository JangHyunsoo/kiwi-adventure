using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private GameObject room_frame_prefab;
    
    private Transform[,] room_transforms;
    private Room[,] room_components_;
    private Vector2[,] real_pos;
    private bool[,] room_exists;
    private bool[,] done_open_door;

    [SerializeField]
    private float room_size_ = 15f;
    public float room_size { get => room_size_; }
    [SerializeField]
    private int map_width_size_ = 21;
    public int map_width_size { get => map_width_size_; }
    [SerializeField]
    private int map_height_size_ = 21;
    public int map_height_size { get => map_height_size_; }

    [SerializeField]
    private int goal_count = 50;
    [SerializeField]
    private int curr_count = 0;


    private void initRoomData()
    {
        room_transforms = new Transform[map_width_size_, map_height_size_];
        room_components_ = new Room[map_width_size_, map_height_size_];
        real_pos = new Vector2[map_width_size_, map_height_size_];
        room_exists = new bool[map_width_size_, map_height_size_];
        done_open_door = new bool[map_width_size_, map_height_size_];

        for (int y = 0; y < map_height_size_; y++)
        {
            for(int x = 0; x < map_width_size_; x++)
            {
                real_pos[x, y] = new Vector2(room_size / 2 + (room_size * x), room_size / 2 - (room_size * y));
                room_exists[x, y] = false;
                done_open_door[x,y] = false;
            }
        }
    }

    private void createFrame(Vector2Int _pos)
    {
        if (isExist(_pos)) return; // 수정해야함.

        room_transforms[_pos.x, _pos.y] = Instantiate(room_frame_prefab, real_pos[_pos.x, _pos.y], Quaternion.identity).transform;
        room_components_[_pos.x, _pos.y] = room_transforms[_pos.x, _pos.y].GetComponent<Room>();
        room_components_[_pos.x, _pos.y].createRoom();
        room_transforms[_pos.x, _pos.y].name = _pos.x.ToString() + ", " + _pos.y.ToString();
        room_transforms[_pos.x, _pos.y].SetParent(gameObject.transform);
        room_exists[_pos.x, _pos.y] = true;
        curr_count++;
    }
    private void createRandomRoom()
    {
        int width_center = Mathf.RoundToInt(map_width_size_ / 2);
        int height_center = Mathf.RoundToInt(map_height_size_ / 2);
        int nextCount = 0;
        Vector2Int nowPos = new Vector2Int(width_center, height_center);
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        queue.Enqueue(nowPos);

        while(queue.Count != 0)
        {
            nowPos = queue.Dequeue();
            createFrame(nowPos);
            var canDir = getCanDirection(nowPos);
            if (canDir.Count == 4) nextCount = 4;
            else if (canDir.Count == 0) nextCount = 0;
            else if (canDir.Count == 1) nextCount = 1;
            else if (canDir.Count == 2 || canDir.Count == 3) nextCount = Random.Range(1, 2);

            for(int i = 0; i < nextCount; i++)
            {
                int rand = Random.Range(0, canDir.Count);
                queue.Enqueue(canDir[rand]);
                canDir.RemoveAt(rand);
            }

            if (goal_count <= curr_count) queue.Clear();
        }
    }
    
    private void openRoomsDoor()
    {
       for(int y = 0; y < map_height_size_; y++)
        {
            for(int x = 0; x < map_width_size_; x++)
            {
                if(room_exists[x,y])
                    openRoomDoor(new Vector2Int(x, y));
            }
        }
    }

    private void openRoomDoor(Vector2Int _pos)
    {
        Room room = room_transforms[_pos.x, _pos.y].GetComponent<Room>();

        foreach (Direction dir in Enum.GetValues(typeof(Direction)))
        {
            Vector2Int check_pos = _pos + Utility.direction_pos[dir];
            if (isMap(check_pos))
            {
                if (room_exists[check_pos.x, check_pos.y])
                {
                    room.openDoor(dir);
                }
            } 
        }
    }

    private List<Vector2Int> getCanDirection(Vector2Int _pos)
    {
        List<Vector2Int> result = new List<Vector2Int>();
        
        foreach(Direction dir in Enum.GetValues(typeof(Direction))){
            Vector2Int check_pos = _pos + Utility.direction_pos[dir];
            if (!isExist(check_pos)) result.Add(check_pos);
        }

        return result;
    }

    private bool isMap(Vector2Int _pos)
    {
        return _pos.x >= 0 && _pos.x < map_width_size_ && _pos.y >= 0 && _pos.y < map_height_size_;
    }

    private bool isExist(Vector2Int _pos)
    {
        if (!isMap(_pos)) return true;
        return room_exists[_pos.x,_pos.y];
    }

    public void init()
    {
        initRoomData();
        createRandomRoom();
        openRoomsDoor();
    }
}
