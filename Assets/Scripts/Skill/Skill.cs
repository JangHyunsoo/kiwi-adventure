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

    private bool isKnown_ = false;
    public bool isKnown { get { return isKnown_; } set { isKnown_ = value; } }

    public Skill(SkillData _skill_data, SkillRecipeData _skill_recipe_data, SkillAction _skill_action)
    {
        this.skill_data = _skill_data;
        this.skill_action = _skill_action;
        this.skill_recipe_data = _skill_recipe_data;
        isKnown_ = false;
    }

    public void activate(Vector3 _my_pos, Vector3 _target_pos, string _team)
    {
        skill_action.activate(skill_data.projectile, _my_pos, _target_pos, _team);
    }
}
