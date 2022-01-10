using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireBall : Skill
{
    public override void activate(Vector3 _pos)
    {
        GameObject.Instantiate(projectile, _pos, Quaternion.identity);
    }
}
