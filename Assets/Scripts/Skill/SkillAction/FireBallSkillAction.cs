using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkillAction : SkillAction
{
    public FireBallSkillAction(int _skill_no) : base(_skill_no) { }

    public override void activate(int _level, Entity _entity, Vector3 _target_pos)
    {
        GameObject go =  GameObject.Instantiate(skill_data.projectile, _entity.transform.position, Quaternion.identity);
        go.GetComponent<Projectile>().setProjectile(_level, _entity.transform.position, _target_pos, _entity.gameObject.tag);
    }
}