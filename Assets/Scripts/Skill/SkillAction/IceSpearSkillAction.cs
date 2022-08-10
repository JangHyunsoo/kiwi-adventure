using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpearSkillAction : SkillAction
{
    public IceSpearSkillAction(int _skill_no) : base(_skill_no) { }

    public override void activate(int _level, Vector3 _my_pos, Vector3 _target_pos, string _team)
    {
        GameObject go = GameObject.Instantiate(SkillDataBase.instance.getSkillData(skill_no).projectile, _my_pos, Quaternion.identity);
        go.GetComponent<Projectile>().setLevel(_level);
        go.GetComponent<Projectile>().setPosition(_my_pos, _target_pos);
        go.GetComponent<Projectile>().setTeam(_team);
    }
}
