using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PoisonFleid : SkillAction
{
    public override void activate(GameObject _projectile, Vector3 _my_pos, Vector3 _target_pos, string _team)
    {
        GameObject go = GameObject.Instantiate(_projectile, _target_pos, Quaternion.identity);
        go.GetComponent<Projectile>().setPosition(_my_pos, _target_pos);
        go.GetComponent<Projectile>().setTeam(_team);
    }
}
