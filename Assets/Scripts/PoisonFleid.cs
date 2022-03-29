using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PoisonFleid : SkillAction
{
    public override void activate(GameObject _projectile, Vector3 _my_pos, Vector3 _target_pos)
    {
        GameObject go = GameObject.Instantiate(_projectile, _target_pos, Quaternion.identity);
        go.GetComponent<PoisonFieldProjectile>().setTeam(Utility.PlayerTag);
    }
}
