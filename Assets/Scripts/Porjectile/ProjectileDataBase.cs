using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Á¦°Å 
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

    public void init() { }

    public GameObject getProjectile(ProjectileType _projectile_type)
    {
        return projectile_object_arr_[(int)_projectile_type];
    }
}
