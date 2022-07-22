using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFlied : MonoBehaviour
{
    [SerializeField]
    private Transform enemy_spawn_object_parent_;
    private EnemySpawnObject[] enemy_spawn_object_arr_;

    public void startRoom()
    {
        spawnEnemy();
    }

    public void spawnEnemy()
    {
        enemy_spawn_object_arr_ = enemy_spawn_object_parent_.GetComponentsInChildren<EnemySpawnObject>();
        foreach (var obj in enemy_spawn_object_arr_)
        {
            obj.spawnRandomEnemey();
        }
    }

    public void clear()
    {
        
    }
}
