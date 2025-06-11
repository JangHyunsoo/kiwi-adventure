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
    private SkillData[] skill_data_arr_;
    [SerializeField]
    private SkillRecipeData[] skill_recipe_data_arr_;
    private SkillAction[] skill_action_data_arr_;

    private Skill[] skill_arr_;
    private Dictionary<Rarity, int[]> skill_rarity_dic_ = new Dictionary<Rarity, int[]>();

    public int skill_count { get => skill_data_arr_.Length; }

    public void init()
    {
        Array.Sort<SkillData>(skill_data_arr_, compareSkillNumber);
        Array.Sort<SkillRecipeData>(skill_recipe_data_arr_, compareSkillReecipeNumber);
        initSkillAction();
        initSkill();
        initSkillIndexArrayByRarity();
    }

    private void initSkillAction()
    {
        List<SkillAction> skill_action_list = new List<SkillAction>();
        
        skill_action_list.Add(new FireBallSkillAction(0));
        skill_action_list.Add(new IceSpearSkillAction(1));
        skill_action_list.Add(new DropIceSkillAction(2));
        skill_action_list.Add(new FrostyWindSkillAction(3));
        skill_action_list.Add(new BoltTackleSkillAction(4));

        skill_action_data_arr_ = skill_action_list.ToArray();
        Array.Sort<SkillAction>(skill_action_data_arr_, compareSkillActionNumber);
    }

    private void initSkill()
    {
        skill_arr_ = new Skill[skill_data_arr_.Length];
        for (int i = 0; i < skill_data_arr_.Length; i++)
        {
            skill_arr_[i] = new Skill(i);
        }
    }

    private void initSkillIndexArrayByRarity()
    {
        foreach (Rarity rarity in Enum.GetValues(typeof(Rarity)))
        {
            List<int> skill_index_arr = new List<int>();
            for (int i = 0; i < skill_data_arr_.Length; i++)
            {
                if (skill_data_arr_[i].skill_rarity == rarity)
                {
                    skill_index_arr.Add(skill_data_arr_[i].skill_no);
                }
            }
            skill_rarity_dic_[rarity] = skill_index_arr.ToArray();
        }
    }

    public SkillData getSkillData(int _skill_no)
    {
        return skill_data_arr_[_skill_no];
    }

    public SkillRecipeData getSkillRecipeData(int _skill_no)
    {
        return skill_recipe_data_arr_[_skill_no];
    }

    public Skill getSkill(int _no, int _level)
    {
        Skill skill = skill_arr_[_no];
        skill.level = _level;
        return new Skill(skill);
    }

    public SkillAction getSkillAction(int _skill_no)
    {
        return skill_action_data_arr_[_skill_no];
    }

    public int[] getSkillIndexArrayByRarity(Rarity _rarity)
    {
        return skill_rarity_dic_[_rarity];
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

    private int compareSkillActionNumber(SkillAction _one, SkillAction _other)
    {
        if (_one.skill_no > _other.skill_no) return 1;
        else if (_one.skill_no < _other.skill_no) return -1;
        else return 0;
    }
}