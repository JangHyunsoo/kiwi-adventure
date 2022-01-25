using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Transform[] door_tr_list_;
    [SerializeField]
    private Transform reward_spawn_point_;
    [SerializeField]
    private Transform enmey_spawn_point_parents_;
    private Transform[] enemy_spawn_points_;
    private List<Transform> door_list = new List<Transform>();
    
    private void Start()
    {
        createRandomDoor();
        enemy_spawn_points_ = Utility.getChildsTransform(enmey_spawn_point_parents_);
        EnemySpawnManager.instance.spawnEnemy(0, enemy_spawn_points_[1].position);
    }

    public void createRandomDoor()
    {
        int door_count = Random.Range(2, 4);

        for (int i = 0; i < door_count; i++)
        {
            door_list.Add(Instantiate(StageManager.instance.getRandomDoorPrefab()
                , door_tr_list_[i].position, Quaternion.identity).transform);
        }
    }
    public void spawnMonster()
    {

    }

    public void createBossDoor()
    {

    }
}
