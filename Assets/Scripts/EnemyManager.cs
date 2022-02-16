using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager _instance;
    public static EnemyManager instance
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
    private EnemyHpGauge enemy_hp_gauge_;
    private List<EnemyEntity> target_enemy_ = new List<EnemyEntity>();

    public void addTargetEnemey(EnemyEntity _enemy)
    {
        target_enemy_.Add(_enemy);
    }

    public void removeTargetEnemey(EnemyEntity _enemy)
    {
        target_enemy_.Remove(_enemy);
    }

    public bool isContainEnemy(EnemyEntity _enemy)
    {
        return target_enemy_.Contains(_enemy);
    }

    public void Update()
    {
        if (target_enemy_.Count != 0) {
            enemy_hp_gauge_.gameObject.SetActive(true);
            enemy_hp_gauge_.updateHpGauge(target_enemy_[0].getHpPersent());
        }
        else
        {
            enemy_hp_gauge_.gameObject.SetActive(false);
        }
    }
}
