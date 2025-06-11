using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataBase : MonoBehaviour
{
    [SerializeField]
    private EnemyData[] enemy_datas;

    private static EnemyDataBase _instance;
    public static EnemyDataBase instance
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
    public EnemyData getEnemy(int _no)
    {
        return enemy_datas[_no];
    }
}
