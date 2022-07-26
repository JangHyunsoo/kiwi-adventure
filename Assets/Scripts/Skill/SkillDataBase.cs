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

    private Dictionary<Rarity, int[]> skill_rarity_dic_ = new Dictionary<Rarity, int[]>();

    private List<Skill> skill_list = new List<Skill>();

    private int count_ = 0;

    public void init()
    {
        Array.Sort<SkillData>(skill_data_list, compareSkillNumber);
        Array.Sort<SkillRecipeData>(skill_recipe_data_list, compareSkillReecipeNumber);
        iunitSkillIndexArrayByRarity();
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
        if (_one.skill_no > _other.skill_no) return 1;
        else if (_one.skill_no < _other.skill_no) return -1;
        else return 0;
    }

    private void iunitSkillIndexArrayByRarity()
    {
        foreach (Rarity rarity in Enum.GetValues(typeof(Rarity)))
        {
            List<int> skill_index_arr = new List<int>();
            for (int i = 0; i < skill_data_list.Length; i++)
            {
                if (skill_data_list[i].skill_rarity == rarity)
                {
                    skill_index_arr.Add(skill_data_list[i].skill_no);
                }
            }
            skill_rarity_dic_[rarity] = skill_index_arr.ToArray();
        }
    }


    public SkillData getSkillData(int _no)
    {
        return skill_data_list[_no];
    }
    public SkillRecipeData getSkillRecipeData(int _no)
    {
        return skill_recipe_data_list[_no];
    }
    public Skill getSkill(int _no, int _level)
    {
        Skill skill = skill_list[_no];
        skill.level = _level;
        return new Skill(skill);
    }
    public int[] getSkillIndexArrayByRarity(Rarity _rarity)
    {
        return skill_rarity_dic_[_rarity];
    }
}