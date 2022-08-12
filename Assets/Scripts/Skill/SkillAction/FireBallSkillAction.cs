using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkillAction : SkillAction
{
    public FireBallSkillAction(int _skill_no) : base(_skill_no) { }

    public override void activate(int _level, Vector3 _my_pos, Vector3 _target_pos, string _team)
    {
        GameObject go =  GameObject.Instantiate(skill_data.projectile, _my_pos, Quaternion.identity);
        go.GetComponent<Projectile>().setProjectile(_level, _my_pos, _target_pos, _team);
    }
}