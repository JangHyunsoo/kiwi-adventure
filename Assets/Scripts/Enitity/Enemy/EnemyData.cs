using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : Status
{
    [SerializeField]
    private EnemyType enemy_type_;
    public EnemyType enemy_type { get => enemy_type_; }
}
