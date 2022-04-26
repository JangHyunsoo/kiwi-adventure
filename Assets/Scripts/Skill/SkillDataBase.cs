using System;
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
    private SkillData[] skill_data_list;
    [SerializeField]
    private SkillRecipeData[] skill_recipe_data_list;

    private List<Skill> skill_list = new List<Skill>();

    private int count_ = 0;

    public void init()
    {
        Array.Sort<SkillData>(skill_data_list, compareSkillNumber);
        Array.Sort<SkillRecipeData>(skill_recipe_data_list, compareSkillReecipeNumber);
        addSkill(new FireBall());
        addSkill(new PoisonFleid());
    }

    private void addSkill(SkillAction _skill_action)
    {
        skill_list.Add(new Skill(skill_data_list[count_], skill_recipe_data_list[count_], _skill_action));
        count_++;
    }

    private int compareSkillNumber(SkillData _one, SkillData _other)
    {
        if (_one.skill_no > _other.skill_no) return 1;
        else if (_one.skill_no < _other.skill_no) return -1;
        else return 0;
    }

    private int compareSkillReecipeNumber(SkillRecipeData _one, SkillRecipeData _other)
    {
        return compareSkillNumber(_one.skill_data, _other.skill_data);
    }
    
    public SkillData getSkillData(int _no)
    {
        return skill_data_list[_no];
    }
    public SkillRecipeData getSkillRecipeData(int _no)
    {
        return skill_recipe_data_list[_no];
    }
    public Skill getSkillRecipe(int _no)
    {
        Skill skill = skill_list[_no];
        skill.isKnown = false;
        return skill_list[_no];
    }
    public Skill getSkill(int _no)
    {
        Skill skill = skill_list[_no];
        skill.isKnown = true;
        return skill_list[_no];
    }
}