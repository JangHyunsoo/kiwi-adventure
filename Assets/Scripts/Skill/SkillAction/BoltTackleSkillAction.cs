using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltTackleSkillAction : SkillAction    
{
    public BoltTackleSkillAction(int _skill_no) : base(_skill_no) { }

    public override void activate(int _level, Entity _entity, Vector3 _target_pos)
    {
        _entity.GetComponent<EntityMoveSkillController>().startSkillMove(_target_pos, skill_data.projectile, skill_data.projectile_speed[_level]);
    }
}
