using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireBall : Skill
{
    public override void activate(Vector3 _my_pos, Vector3 _target_pos)
    {
        GameObject go =  GameObject.Instantiate(projectile, _my_pos, Quaternion.identity);
        go.GetComponent<FireBallProjectile>().setPosition(_my_pos, _target_pos);
    }
}