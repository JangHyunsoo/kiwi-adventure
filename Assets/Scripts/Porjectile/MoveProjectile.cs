using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : Projectile
{
    private Vector3 direction_;

    private double delay_time_;
    private double current_delay_time_ = 0d;

    public override void init()
    {
        delay_time_ = 5d;
        direction_ = (target_pos_ - transform.position).normalized;
    }
    public override void activate()
    {
        transform.Translate(direction_ * Time.deltaTime * 10f);
        current_delay_time_ += Time.deltaTime;

        if(delay_time_ < current_delay_time_)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void onHit(Collider2D collision)
    {
        if (collision.tag != team_)
        {
            if (collision.tag == "Player" || collision.tag == "Monster")
            {
                collision.GetComponent<Entity>().hitDamage(1);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onHit(collision);
    }

}
