using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill
{
    private int skill_no_;
    public int skill_no { get => skill_no_; }
    private int level_ = 0;
    public int level { get { return level_; } set { level_ = value; } }
    private float curr_cooltime_ = 0f;

    public SkillData skill_data;
    public SkillAction skill_action;
    public SkillRecipeData skill_recipe_data;


    public bool is_known { get => level_ != 0; }
    public bool is_ready { get => curr_cooltime_ <= 0; }


    public Skill(int _skill_no)
    {
        skill_no_ = _skill_no;
        skill_data = SkillDataBase.instance.getSkillData(skill_no_);
        skill_action = SkillDataBase.instance.getSkillAction(skill_no);
        skill_recipe_data = SkillDataBase.instance.getSkillRecipeData(skill_no_);
        level_ = 0;
    }

    public Skill(Skill _skill)
    {
        skill_no_ = _skill.skill_no;
        skill_data = SkillDataBase.instance.getSkillData(skill_no_);
        skill_action = SkillDataBase.instance.getSkillAction(skill_no);
        skill_recipe_data = SkillDataBase.instance.getSkillRecipeData(skill_no_);
        level_ = _skill.level;
    }

    public void activate(Vector3 _my_pos, Vector3 _target_pos, string _team)
    {
        startCoolTime();
        skill_action.activate(level - 1, _my_pos, _target_pos, _team);
    }

    public void startCoolTime()
    {
        curr_cooltime_ = skill_data.cool_time[level];
    }

    public void updateCoolTime()
    {
        if (curr_cooltime_ <= 0)
        {
            curr_cooltime_ = 0;
            return;
        }

        curr_cooltime_ -= Time.deltaTime;
    }

    public float getCooltiemAmount()
    {
        float amount = curr_cooltime_ / skill_data.cool_time[level];
        if (amount > 0) return amount;
        else return 0f;
    }
}
