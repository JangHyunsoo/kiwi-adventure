using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PoisonFleid : Skill
{
    public override void activate(Transform _my_tr, Vector3 _target_pos)
    {
        GameObject go = GameObject.Instantiate(projectile, _my_tr.position, Quaternion.identity);
        go.GetComponent<FireBallProjectile>().setTeam(_my_tr.tag);
    }
}
