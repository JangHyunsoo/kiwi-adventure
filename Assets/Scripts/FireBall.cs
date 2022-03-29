using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireBall : SkillAction
{
    public override void activate(GameObject _projectile, Vector3 _my_pos, Vector3 _target_pos)
    {
        GameObject go =  GameObject.Instantiate(_projectile, _my_pos, Quaternion.identity);
        go.GetComponent<FireBallProjectile>().setPosition(_my_pos, _target_pos);
        go.GetComponent<FireBallProjectile>().setTeam(Utility.PlayerTag);
    }
}