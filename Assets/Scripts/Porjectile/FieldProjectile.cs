using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldProjectile : Projectile
{
    private float curr_during_time_;
    private float collider_size_;

    
    public override void init()
    {
        curr_during_time_ = 0f;
        collider_size_ = GetComponent<CircleCollider2D>().radius;
        GetComponent<CircleCollider2D>().radius = 0f;
    }

    public override void openingAction()
    {
        GetComponent<CircleCollider2D>().radius = collider_size_;
        curr_during_time_ += Time.deltaTime;

        if (curr_during_time_ >= skill_data_.during_time[skill_level_])
        {
            is_crash_ = true;
        }
    }

    public override void collisionEntity(Collider2D _collision)
    {
        Debug.Log(_collision.name);
        _collision.GetComponent<Entity>().hitDamage(skill_data_.skill_damage[skill_level_]);
    }
}
