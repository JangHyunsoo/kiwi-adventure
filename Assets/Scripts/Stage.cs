using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private GameObject room_frame_prefab;

    private Transform[,] room_transforms;
    private Vector2[,] real_pos;
    private bool[,] room_exists;
    private bool[,] done_open_door;
    

    [SerializeField]
    private int map_size = 21;

    [SerializeField]
    private int goal_count = 50;
    private int curr_count = 0;

    private void initRoomData()
    {
        room_transforms = new Transform[map_size, map_size];
        real_pos = new Vector2[map_size, map_size];
        room_exists = new bool[map_size, map_size];
        done_open_door = new bool[map_size, map_size];

        for (int y = 0; y < map_size; y++)
        {
            for(int x = 0; x < map_size; x++)
            {
                real_pos[x, y] = new Vector2(-5 + (10 * x), 5 - (10 * y));
                room_exists[x, y] = false;
                done_open_door[x,y] = false;
            }
        }
    }

    private void createFrame(Vector2Int _pos)
    {
        room_transforms[_pos.x, _pos.y] = Instantiate(room_frame_prefab, real_pos[_pos.x, _pos.y], Quaternion.identity).transform;
        room_exists[_pos.x, _pos.y] = true;
        curr_count++;
    }
    private void createRandomRoom()
    {
        int center = Mathf.RoundToInt(map_size / 2);
        int nextCount = 0;
        Vector2Int nowPos = new Vector2Int(center, center);
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        queue.Enqueue(nowPos);

        while(queue.Count != 0)
        {
            nowPos = queue.Dequeue();
            Debug.Log(nowPos);
            createFrame(nowPos);
            var canDir = getCanDirection(nowPos);
            Debug.Log(canDir);
            if (canDir.Count == 4) nextCount = 4;
            else if (canDir.Count == 0) nextCount = 0;
            else if (canDir.Count == 1) nextCount = Random.Range(0, 1);
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
        return _pos.x >= 0 && _pos.x < map_size && _pos.y >= 0 && _pos.y < map_size;
    }

    private bool isExist(Vector2Int _pos)
    {
        if (!isMap(_pos)) return true;
        return room_exists[_pos.x,_pos.y];
    }

    private void Start()
    {
        initRoomData();
        createRandomRoom();
    }
}
