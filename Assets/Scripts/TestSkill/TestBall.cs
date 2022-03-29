using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : SkillAction
{
    public override void activate(GameObject _projectile, Vector3 _my_pos, Vector3 _target_pos)
    {
        var obj = GameObject.Instantiate(_projectile, _my_pos, Quaternion.identity);
        obj.GetComponent<FireBallProjectile>().setPosition(_my_pos, _target_pos);
        obj.GetComponent<FireBallProjectile>().setTeam(Utility.PlayerTag);
    }
}
