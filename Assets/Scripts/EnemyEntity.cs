using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemy_data_;
    [SerializeField]
    public int current_hp_;
    private bool is_die_;

    public EnemyData enemy_data { get => enemy_data_; set => enemy_data_ = value; }
    public bool is_die { get => is_die_; }

    public virtual void Awake()
    {
        current_hp_ = enemy_data_.max_hp;
    }

    public void hitDamage(int _damage)
    {
        current_hp_ -= _damage;
        if (current_hp_ <= 0)
        {
            current_hp_ = 0;
            Destroy(gameObject);
        }
    }
    public float getHpPersent()
    {
        return (float)current_hp_ / (float)enemy_data.max_hp;
    }

    private void OnDestroy()
    {
        EnemyManager.instance.removeEnemy(this);
        EnemyManager.instance.removeTargetEnemey(this);
        if (EnemyManager.instance.isEnemyEmpty())
        {
            StageManager.instance.clearStage();
        }
    }
}
