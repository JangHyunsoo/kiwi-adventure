using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillAction
{
    public virtual void activate(GameObject _projectile, Vector3 _my_pos, Vector3 _target_pos) { }

}
