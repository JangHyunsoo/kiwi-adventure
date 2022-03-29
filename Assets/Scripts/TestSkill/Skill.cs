using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill
{
    private SkillData skill_data_;
    public SkillData skill_data { get => skill_data_; set => skill_data_ = value; }
    private SkillAction skill_action_;
    public SkillAction skill_action { get => skill_action_; set => skill_action_ = value; }
    

    public Skill(SkillData _skill_data, SkillAction _skill_action)
    {
        this.skill_data = _skill_data;
        this.skill_action = _skill_action;
    }



    public void activate(Vector3 _my_pos, Vector3 _target_pos, string _team)
    {
        skill_action.activate(skill_data.projectile, _my_pos, _target_pos, _team);
    }
}
