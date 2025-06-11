using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill
{
    private int skill_no_;
    public int skill_no { get => skill_no_; }
    private int level_ = 0;
    public int level { get { return level_; } set { level_ = value; } }

    public SkillData skill_data;
    public SkillAction skill_action;
    public SkillRecipeData skill_recipe_data;

    public bool is_known { get => level_ != 0; }

    public Skill(int _skill_no)
    {
        skill_no_ = _skill_no;
        skill_data = SkillDataBase.instance.getSkillData(skill_no_);
        skill_action = SkillDataBase.instance.getSkillAction(skill_no);
        skill_recipe_data = SkillDataBase.instance.getSkillRecipeData(skill_no_);
        level_ = 0;
    }
    public Skill(Skill _skill) : this(_skill.skill_no)
    {
        level_ = _skill.level;
    }

    public void activate(Entity _entity, Vector3 _target_pos)
    {
        skill_action.activate(level - 1, _entity, _target_pos);
    }

    public float getCoolTime()
    {
        return skill_data.cool_time[level - 1];
    }
}
