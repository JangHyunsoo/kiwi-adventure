using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySqawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy_prefab_;
    // Room Data를 가지고 있는 Stage를 받아서, Stage 갱신 시, Stage 내, 모든 sqawn point에서
    // Enemy를 소환해줌.

    private static EnemySqawnManager _instance;
    public static EnemySqawnManager instance
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            sqawnEnemy(0);
        }
    }
    public void sqawnEnemy(int _no)
    {
        // enemy_prefab_.GetComponent<EnemyEntity>().enemy_data = EnemyDataBase.instance.getEnemy(_no);
        enemy_prefab_.GetComponent<SpriteRenderer>().sprite = EnemyDataBase.instance.getEnemy(_no).obj_sprite;
        Instantiate(enemy_prefab_, new Vector3(1, 1, 0), Quaternion.identity);
    }


}
