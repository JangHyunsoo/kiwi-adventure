using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill
{
    private SkillData skill_data_;
    public SkillData skill_data { get => skill_data_; set => skill_data_ = value; }
    private SkillAction skill_action_;
    public SkillAction skill_action { get => skill_action_; set => skill_action_ = value; }
    private SkillRecipeData skill_recipe_data_;
    public SkillRecipeData skill_recipe_data { get => skill_recipe_data_; set => skill_recipe_data_ = value; }

    private int level_ = 0;
    private float curr_cooltime_ = 0f;

    public int level { get { return level_; } set { level_ = value; } }
    public bool is_known { get => level_ != 0; }
    public bool is_ready { get => curr_cooltime_ <= 0; }

    public Skill(SkillData _skill_data, SkillRecipeData _skill_recipe_data, SkillAction _skill_action)
    {
        skill_data_ = _skill_data;
        skill_action_ = _skill_action;
        skill_recipe_data_ = _skill_recipe_data;
        skill_action_.setProjectile(_skill_data);
        level_ = 0;
    }

    
    public Skill(Skill _skill)
    {
        skill_data_ = _skill.skill_data;
        skill_action_ = _skill.skill_action;
        skill_recipe_data_ = _skill.skill_recipe_data;
        skill_action_.setProjectile(_skill.skill_data);
        level_ = _skill.level;
    }

    public void activate(Vector3 _my_pos, Vector3 _target_pos, string _team)
    {
        startCoolTime();
        skill_action.activate(_my_pos, _target_pos, _team);
    }

    public void startCoolTime()
    {
        curr_cooltime_ = skill_data_.cool_time;
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
        float amount = curr_cooltime_ / skill_data_.cool_time;
        if (amount > 0) return amount;
        else return 0f;
    }
}
