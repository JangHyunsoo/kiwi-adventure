using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : Projectile
{
    private Vector3 direction_;
    private double current_skill_distance = 0d;

    public override void init()
    {
        direction_ = (target_pos_ - transform.position).normalized;
        transform.rotation = Utility.getDirecitonToRotation(direction_);
        is_ready_ = false;
    }

    public override void openingAction()
    {
        current_skill_distance += Time.deltaTime * skill_data_.projectile_speed[skill_level_];
        transform.position += (direction_ * Time.deltaTime * skill_data_.projectile_speed[skill_level_]);

        if (skill_data_.casting_range[skill_level_] < current_skill_distance)
        {
            is_crash_ = true;
        }
    }

    public override void collisionEntity(Collider2D _collision)
    {
        _collision.GetComponent<Entity>().hitDamage(skill_data_.skill_damage[skill_level_]);
        is_crash_ = true;
    }

    public override void destroyAction()
    {
        Destroy(gameObject);
    }
}
