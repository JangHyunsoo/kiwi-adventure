using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : Status
{
    [SerializeField]
    private Enemytype enemy_type_;
    public Enemytype enemy_type { get => enemy_type_; }
}
