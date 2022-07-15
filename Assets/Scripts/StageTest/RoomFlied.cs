using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFlied : MonoBehaviour
{
    [SerializeField]
    private Transform enemy_spawn_object_holder_;
    private EnemySpawnObject[] enemy_spawn_object_list_;

    public void spawnEnemy()
    {
        enemy_spawn_object_list_ = enemy_spawn_object_holder_.GetComponentsInChildren<EnemySpawnObject>();
        foreach (var obj in enemy_spawn_object_list_)
        {
            obj.spawnRandomEnemey();
        }
    }
}
