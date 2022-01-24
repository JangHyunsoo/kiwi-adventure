using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory _instance = null;

    private int[] skill_equipment;
    private int curr_skill_idx;

    public static Inventory instance
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
    private void Start()
    {
        init();
    }
    private void init()
    {
        skill_equipment = new int[5] { 0, 0, 0, 0, 0 };
        skill_equipment[0] = 1;
        curr_skill_idx = 0;
    }
    public Skill getCurrSkill()
    {
        return SkillDataBase.instance.getSkill(skill_equipment[curr_skill_idx]);
    }

}
