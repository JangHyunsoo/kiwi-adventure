using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    private static StageManager _instance;
    public static StageManager instance
    {
        get
        {
            if (_instance == null) { return null; }
            else { return _instance; }
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField]
    private GameObject[] exit_door_prefab_list_;
    [SerializeField]
    private GameObject[] room_prefab_list_;
    [SerializeField]
    private Transform room_holder_;

    [SerializeField]
    private int room_height_;
    public int room_height { get => room_height_; }
    [SerializeField]
    private int room_width_;
    public int room_width { get => room_width_; }

    [SerializeField]
    private Vector2Int curr_player_pos_;
    private Vector2[,] room_pos_array_;
    private Transform[,] room_tr_array_;
    private Room[,] room_cp_array_;

    public void init()
    {
        curr_player_pos_ = new Vector2Int(1, 0);
        room_pos_array_ = new Vector2[room_width_, room_height_];
        room_tr_array_ = new Transform[room_width_, room_height_];
        room_cp_array_ = new Room[room_width_, room_height_];
        for (int x = 0; x < room_width_; x++)
        {
            for (int y = 0; y < room_height_; y++)
            {
                room_pos_array_[x, y] = new Vector2(x * 40f, y * 40f);
                room_tr_array_[x, y] = Instantiate(room_prefab_list_[0], room_pos_array_[x, y], Quaternion.identity).transform;
                room_cp_array_[x, y] = room_tr_array_[x, y].GetComponent<Room>();
                room_cp_array_[x, y].room_stage_pos = new Vector2Int(x, y);
                room_cp_array_[x, y].init();
                room_tr_array_[x, y].SetParent(room_holder_);
            }
        }
    }
    private void startBattle()
    {
        room_cp_array_[curr_player_pos_.x, curr_player_pos_.y].spawnMonster();
        if (EnemyManager.instance.isEnemyEmpty())
        {
            clearStage();
        }
    }
    public void clearStage()
    {
        room_cp_array_[curr_player_pos_.x, curr_player_pos_.y].setDoor(true);
    }
    public void moveRoom(int _idx) // 0 = Right, 1 = Middle, 2 = Left
    {
        curr_player_pos_.y++;
        if (_idx == 0)
        {
            curr_player_pos_.x--;
        }
        else if (_idx == 2)
        {
            curr_player_pos_.x++;
        }
    }
    public void enterRoom()
    {
        PlayerManager.instance.movePlayer(getCurrStagePlayerSpawnPos());
        startBattle();
    }
    public GameObject getDoorPrefab(int _id)
    {
        return exit_door_prefab_list_[_id];
    }
    public GameObject getRandomDoorPrefab()
    {
        return exit_door_prefab_list_[Random.Range(0, exit_door_prefab_list_.Length)];
    }
    public Vector2Int getCurrPlayerStagePos()
    {
        return curr_player_pos_;
    }
    public Vector2 getCurrStagePlayerSpawnPos()
    {
        return room_cp_array_[curr_player_pos_.x, curr_player_pos_.y].player_spawn_point.position;
    }
    
}
