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
    private Stage stage_;
    private Vector2Int curr_map_pos_ = Vector2Int.zero;
    public Vector2Int curr_map_pos { get => curr_map_pos_; }
    public Vector2 curr_real_pos { get => calculRealPos(curr_map_pos_); }


    public void init()
    {
        stage_.init();
        int width_center = Mathf.RoundToInt(stage_.map_width_size / 2);
        int height_center = Mathf.RoundToInt(stage_.map_height_size / 2);
        curr_map_pos_ = new Vector2Int(width_center, height_center);
    }

    public void clearStage()
    {
        // 스테이지 클리어
    }

    public Vector2 calculRealPos(Vector2Int _pos)
    {
        float room_size = stage_.room_size;
        return new Vector2(room_size / 2 + (room_size * _pos.x), room_size / 2 - (room_size * _pos.y));
    }

    public void startCurrRoomBattle()
    {
        
    }
}
