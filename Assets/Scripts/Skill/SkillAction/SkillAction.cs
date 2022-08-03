using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillAction
{
    public GameObject projectile_;

    public virtual void activate(Vector3 _my_pos, Vector3 _target_pos, string _team) { }


    public virtual void setProjectile(SkillData _skill_data)
    {
        switch(_skill_data.projectile_type)
        {
            case ProjectileType.MOVE:
                projectile_ = SkillDataBase.instance.move_projectile;
                break;
            case ProjectileType.FIELD:
                projectile_ = SkillDataBase.instance.field_projectile;
                break;
        }

        // 呈啊 富沁带 规过
        // 

        projectile_.GetComponent<Projectile>().setData(_skill_data);
    }
}