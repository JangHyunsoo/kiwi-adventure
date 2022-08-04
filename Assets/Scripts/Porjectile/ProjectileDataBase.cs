using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDataBase : MonoBehaviour
{
    private static ProjectileDataBase _instance;
    public static ProjectileDataBase instance
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
    private GameObject[] projectile_object_arr_;

    private Dictionary<int, int> projectile_dic_ = new Dictionary<int, int>();

    public void init()
    {
        setDictioanry();
    }

    private void setDictioanry()
    {
        for(int i = 0; i < projectile_object_arr_.Length; i++)
        {
            projectile_dic_[projectile_object_arr_[i].GetComponent<Projectile>().skill_no] = i;
        }
    }

    public GameObject getProjectile(int _skill_no)
    {
        return projectile_object_arr_[projectile_dic_[_skill_no]];
    }

}
