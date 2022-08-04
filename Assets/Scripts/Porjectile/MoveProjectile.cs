using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : Projectile
{
    private Vector3 direction_;
    
    private double current_skill_distance = 0d;

    [SerializeField]
    private bool is_crash_with_object_ = true;

    public override void init()
    {
        direction_ = (target_pos_ - transform.position).normalized;
        transform.rotation = Utility.getDirecitonToRotation(target_pos_);
    }
    public override void activate()
    {
        current_skill_distance += Time.deltaTime * skill_data_.projectile_speed;
        transform.Translate(direction_ * Time.deltaTime * skill_data_.projectile_speed);

        if(skill_data_.casting_range < current_skill_distance)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void onHit(Collider2D collision)
    {
        collision.GetComponent<Entity>().hitDamage(skill_data_.skill_damage);
        Destroy(gameObject);
    }

    protected virtual void onCrashObject() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
            return;
        }
        else if(collision.tag == "Object")
        {
            if (is_crash_with_object_)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                onCrashObject();
            }
        }

        if (collision.tag != team_)
        {
            if (collision.tag == "Player" || collision.tag == "Monster")
            {
                onHit(collision);
            }
        }
    }

}
