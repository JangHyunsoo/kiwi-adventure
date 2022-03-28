using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Vector2Int room_stage_pos_;
    [SerializeField]
    private Transform[] door_tr_list_;
    [SerializeField]
    private Transform reward_spawn_point_;
    [SerializeField]
    private Transform enmey_spawn_point_parents_;
    [SerializeField]
    private Transform player_spawn_point_;
    [SerializeField]
    private Transform door_holder_;
    private Transform[] enemy_spawn_points_;
    private List<Transform> door_list_ = new List<Transform>();

    public Vector2Int room_stage_pos { get => room_stage_pos_; set => room_stage_pos_ = value; }
    public Transform player_spawn_point { get => player_spawn_point_; }
    
    public void init()
    {
        createDoor();
        setDoor(false);
        enemy_spawn_points_ = Utility.getChildsTransform(enmey_spawn_point_parents_);
    }
    public void createDoor()
    {
        List<int> exit_idx_list = StageManager.instance.getExitDoorIndex(room_stage_pos_);

        foreach(int idx in exit_idx_list)
        {
            createDoorByIndex(idx);
        }
    }

    private void createDoorByIndex(int _idx)
    {
        Transform door = Instantiate(StageManager.instance.getDoorPrefab(0)
                , door_tr_list_[_idx].position, Quaternion.identity).transform;
        door.GetComponent<ExitDoor>().enter_id = _idx;
        door_list_.Add(door);
        door.SetParent(door_holder_);

    }
    public void spawnMonster()
    {
        for (int i = 0; i < enemy_spawn_points_.Length; i++)
        {
            EnemyManager.instance.spawnEnemy(0, enemy_spawn_points_[i].position);
        }
    }

    public void createBossDoor()
    {

    }

    public void setDoor(bool _flag)
    {
        foreach(Transform door in door_list_)
        {
            door.gameObject.SetActive(_flag);
        }
    }
}
