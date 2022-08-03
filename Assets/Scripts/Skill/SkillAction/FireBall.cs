using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireBall : SkillAction
{
    public override void activate(Vector3 _my_pos, Vector3 _target_pos, string _team)
    {
        GameObject go =  GameObject.Instantiate(SkillDataBase.instance.move_projectile, _my_pos, Quaternion.identity);
        go.GetComponent<Projectile>().setPosition(_my_pos, _target_pos);
        go.GetComponent<Projectile>().setTeam(_team);
    }
}