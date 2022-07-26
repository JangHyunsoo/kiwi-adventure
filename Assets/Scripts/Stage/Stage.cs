using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private GameObject room_prefab_;
    
    private Dictionary<Vector2Int, Transform> room_transform_dic_;
    private Dictionary<Vector2Int, Room> room_component_dic_;
    private bool[,] room_exist_2d_;
    private Vector2[,] real_pos_2d_;
    private bool[,] done_open_door_2d_;
    private bool[,] cleared_room_2d_;

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
    private int goal_count_ = 50;
    [SerializeField]
    private int curr_count_ = 0;

    [SerializeField]
    [Range(0f, 1f)]
    private float next_cnt_incr_percent_ = 0.3f;
    [SerializeField]
    [Range(0f, 1f)]
    private float straight_percent_ = 0.7f;

    private void initRoomData()
    {
        room_transform_dic_ = new Dictionary<Vector2Int, Transform>();
        room_component_dic_ = new Dictionary<Vector2Int, Room>();
        real_pos_2d_ = new Vector2[map_width_size_, map_height_size_];
        room_exist_2d_ = new bool[map_width_size_, map_height_size_];
        done_open_door_2d_ = new bool[map_width_size_, map_height_size_];
        cleared_room_2d_ = new bool[map_width_size_, map_height_size_];

        for (int y = 0; y < map_height_size_; y++)
        {
            for(int x = 0; x < map_width_size_; x++)
            {
                real_pos_2d_[x, y] = new Vector2(room_size / 2 + (room_size * x), room_size / 2 - (room_size * y));
                room_exist_2d_[x, y] = false;
                done_open_door_2d_[x,y] = false;
                cleared_room_2d_[x, y] = false;
            }
        }
    }

    private void createFrame(Vector2Int _pos)
    {
        if (isExist(_pos)) return; // 수정해야함.

        room_transform_dic_[_pos] = Instantiate(room_prefab_, real_pos_2d_[_pos.x, _pos.y], Quaternion.identity).transform;
        room_component_dic_[_pos] = room_transform_dic_[_pos].GetComponent<Room>();
        room_component_dic_[_pos].createRoom();
        room_transform_dic_[_pos].name = _pos.x.ToString() + ", " + _pos.y.ToString();
        room_transform_dic_[_pos].SetParent(gameObject.transform);
        room_exist_2d_[_pos.x, _pos.y] = true;
        curr_count_++;
    }

    private class VecData
    {
        public Vector2Int vec;
        public Direction dir;
        public VecData(Vector2Int _vec, Direction _dir)
        {
            vec = _vec;
            dir = _dir;
        }
    }

    private void createRandomRoom()
    {
        int width_center = Mathf.RoundToInt(map_width_size_ / 2);
        int height_center = Mathf.RoundToInt(map_height_size_ / 2);
        int nextCount = 0;
        VecData now_data = new VecData(new Vector2Int(width_center, height_center), Direction.BOTTOM);
        Queue<VecData> queue = new Queue<VecData>();
        queue.Enqueue(now_data);

        while(queue.Count != 0)
        {
            now_data = queue.Dequeue();
            createFrame(now_data.vec);
            var canDir = getCanDirection(now_data.vec);
            if (canDir.Count == 4) nextCount = 4;
            else if (canDir.Count == 0) nextCount = 0;
            else if (canDir.Count == 1) nextCount = 1;
            else if (canDir.Count == 2 || canDir.Count == 3)
            {
                if(Utility.randIndex(next_cnt_incr_percent_, 1 - next_cnt_incr_percent_) == 0)
                {
                    nextCount = 2;
                }
                else
                {
                    nextCount = 1;
                }
            }

            for(int i = 0; i < nextCount; i++)
            {
                int rand = randStraight(now_data, canDir);
                queue.Enqueue(canDir[rand]);
                canDir.RemoveAt(rand);
            }

            if (goal_count_ == curr_count_) queue.Clear();
        }
    }

    private int randStraight(VecData _now, List<VecData> _move_list)
    {
        int straight_idx = -1;
        List<int> other_idxs = new List<int>();
        for(int i = 0; i < _move_list.Count; i++)
        {
            if(_move_list[i].dir == _now.dir)
            {
                straight_idx = i;
            }
            else
            {
                other_idxs.Add(i);
            }
        }

        if(straight_idx == -1)
        {
            return Random.RandomRange(0, _move_list.Count);
        }
        else
        {
            int rand = Utility.randIndex(straight_percent_, 1 - straight_percent_);

            if (other_idxs.Count == 0 || rand == 0)
            {
                return straight_idx;
            }
            else
            {
                return other_idxs[Random.RandomRange(0, other_idxs.Count)];
            }
        }
    }
    
    private void openRoomsDoor()
    {
       for(int y = 0; y < map_height_size_; y++)
        {
            for(int x = 0; x < map_width_size_; x++)
            {
                if (room_exist_2d_[x, y])
                {
                    openRoomDoor(new Vector2Int(x, y));
                }
            }
        }
    }

    private void openRoomDoor(Vector2Int _pos)
    {
        Room room = room_component_dic_[_pos];

        foreach (Direction dir in Enum.GetValues(typeof(Direction)))
        {
            Vector2Int check_pos = _pos + Utility.direction_pos[dir];
            if (isMap(check_pos))
            {
                if (room_exist_2d_[check_pos.x, check_pos.y])
                {
                    room.openDoor(dir);
                }
            } 
        }
    }

    private List<VecData> getCanDirection(Vector2Int _pos)
    {
        List<VecData> result = new List<VecData>();
        
        foreach(Direction dir in Enum.GetValues(typeof(Direction))){
            Vector2Int check_pos = _pos + Utility.direction_pos[dir];
            if (!isExist(check_pos))
            {
                result.Add(new VecData(check_pos, dir));
            }
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
        return room_exist_2d_[_pos.x,_pos.y];
    }

    public void init()
    {
        initRoomData();
        createRandomRoom();
        openRoomsDoor();
    }

    public void clearRoom(Vector2Int _pos)
    {
        room_component_dic_[_pos].clear();
        cleared_room_2d_[_pos.x, _pos.y] = true;
    }

    public bool isClearedRoom(Vector2Int _pos)
    {
        return cleared_room_2d_[_pos.x, _pos.y];
    }

    public void startBattle(Vector2Int _pos)
    {
        room_component_dic_[_pos].startRoom();
    }
}
