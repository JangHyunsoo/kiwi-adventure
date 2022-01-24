using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PoisonFleid : Skill
{
    public override void activate(Vector3 _my_pos, Vector3 _target_pos)
    {
        GameObject go = GameObject.Instantiate(projectile, _target_pos, Quaternion.identity);
    }
}
