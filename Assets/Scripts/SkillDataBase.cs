using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDataBase : MonoBehaviour
{
    private static SkillDataBase _instance;
    public static SkillDataBase instance
    {
        get
        {
            if (_instance == null) { return null; }
            else { return _instance; }
        }
    }

    [SerializeField]
    public Skill[] skills;

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

    public void init()
    {

    }
    public Skill getSkill(int _no)
    {
        return skills[_no];
    }
}