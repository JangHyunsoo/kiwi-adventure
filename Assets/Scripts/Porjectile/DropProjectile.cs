using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropProjectile : Projectile
{
    [SerializeField]
    private float height_;
    private float projectile_speed_ = 5f;

    public override void init()
    {
        target_pos_ = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y + height_, transform.position.z);
    }

    public override void openingAction()
    {
        transform.position = Vector3.Lerp(transform.position, target_pos_, Time.deltaTime * projectile_speed_);

        if(Vector3.Distance(transform.position, target_pos_) <= Time.deltaTime * projectile_speed_)
        {
            is_crash_ = true;
        }
    }

    public override void collisionEntity(Collider2D _collision)
    {
        _collision.GetComponent<Entity>().hitDamage(skill_data_.skill_damage[skill_level_]);
        is_crash_ = true;
    }

}
