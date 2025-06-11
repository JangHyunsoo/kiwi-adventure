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
    private Transform enemy_holder_;
    [SerializeField]
    private GameObject enemy_prefab_;

    [SerializeField]
    private List<EnemyEntity> all_enemy_arr_ = new List<EnemyEntity>();

    [SerializeField]
    private EnemyHpGauge enemy_hp_gauge_;
    [SerializeField]
    private List<EnemyEntity> target_enemy_arr_ = new List<EnemyEntity>();

    public GameObject spawnEnemy(int _no, Vector3 _pos)
    {
        var enemy_obj = Instantiate(enemy_prefab_, _pos, Quaternion.identity);
        enemy_obj.GetComponent<EnemyEntity>().status_data = EnemyDataBase.instance.getEnemy(_no);
        enemy_obj.GetComponent<SpriteRenderer>().sprite = EnemyDataBase.instance.getEnemy(_no).obj_sprite;
        enemy_obj.transform.SetParent(enemy_holder_);
        addEnemy(enemy_obj.GetComponent<EnemyEntity>());
        return enemy_obj;
    }

    public void addEnemy(EnemyEntity _enemy)
    {
        all_enemy_arr_.Add(_enemy);
    }
    public void removeEnemy(EnemyEntity _enemy)
    {
        if (all_enemy_arr_.Contains(_enemy))
        {
            all_enemy_arr_.Remove(_enemy);
        }
    }

    public bool isEnemyEmpty()
    {
        return all_enemy_arr_.Count == 0;
    }

    public void addTargetEnemey(EnemyEntity _enemy)
    {
        target_enemy_arr_.Add(_enemy);
    }

    public void removeTargetEnemey(EnemyEntity _enemy)
    {
        if (isContainEnemy(_enemy))
        {
            target_enemy_arr_.Remove(_enemy);
        }
    }

    public bool isContainEnemy(EnemyEntity _enemy)
    {
        return target_enemy_arr_.Contains(_enemy);
    }

    public bool isTargetEnemeyuEnmpty()
    {
        return target_enemy_arr_.Count == 0;
    }

    public List<EnemyEntity> getTargetEnemy()
    {
        return target_enemy_arr_;
    }
}