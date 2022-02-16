using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform enemy_holder_;

    [SerializeField]
    private GameObject enemy_prefab_;
    // Room Data를 가지고 있는 Stage를 받아서, Stage 갱신 시, Stage 내, 모든 sqawn point에서
    // Enemy를 소환해줌.

    private List<EnemyEntity> enemy_list_ = new List<EnemyEntity>();
    private EnemyEntity target_enemy;

    private static EnemySpawnManager _instance;
    public static EnemySpawnManager instance
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
    public void spawnEnemy(int _no, Vector3 _pos)
    {
        var enemy_obj = Instantiate(enemy_prefab_, _pos, Quaternion.identity);
        enemy_obj.GetComponent<EnemyEntity>().enemy_data = EnemyDataBase.instance.getEnemy(_no);
        enemy_obj.GetComponent<SpriteRenderer>().sprite = EnemyDataBase.instance.getEnemy(_no).obj_sprite;
        enemy_obj.transform.SetParent(enemy_holder_);
        enemy_list_.Add(enemy_obj.GetComponent<EnemyEntity>());
    }
    public bool isEnemyEmpty()
    {
        return enemy_list_.Count == 0;
    }
    public void Update()
    {

    }
}
