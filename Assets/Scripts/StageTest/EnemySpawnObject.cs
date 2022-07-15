using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnObject : MonoBehaviour
{
    [SerializeField]
    private int[] rand_enemy_list_;
    private Transform curr_enemy_;

    public void spawnRandomEnemey()
    {
        int rand_idx = rand_enemy_list_[Random.Range(0, rand_enemy_list_.Length - 1)];
        curr_enemy_ = EnemyManager.instance.spawnEnemy(rand_idx, transform.position).transform;
    }
}