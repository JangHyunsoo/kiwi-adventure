using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillAction
{
    private int skill_no_;
    public int skill_no { get => skill_no_; }

    private SkillData skill_data_;
    public SkillData skill_data { get => skill_data_; }

    public SkillAction(int _skill_no)
    {
        skill_no_ = _skill_no;
        skill_data_ = SkillDataBase.instance.getSkillData(skill_no_);
    }

    public virtual void activate(int _level, Vector3 _my_pos, Vector3 _target_pos, string _team) { }
}