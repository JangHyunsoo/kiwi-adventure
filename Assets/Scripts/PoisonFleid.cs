using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PoisonFleid : Skill
{
    public override void activate(Transform _my_tr, Vector3 _target_pos)
    {
        GameObject go = GameObject.Instantiate(projectile, _target_pos, Quaternion.identity);
        go.GetComponent<PoisonFieldProjectile>().setTeam(_my_tr.tag);
    }
}
