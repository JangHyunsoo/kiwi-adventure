using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform enemy_holder_;

    [SerializeField]
    private GameObject enemy_prefab_;
    // Room Data�� ������ �ִ� Stage�� �޾Ƽ�, Stage ���� ��, Stage ��, ��� sqawn point����
    // Enemy�� ��ȯ����.

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
    }


}
