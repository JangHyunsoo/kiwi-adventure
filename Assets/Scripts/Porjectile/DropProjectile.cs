using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropProjectile : Projectile
{
    [SerializeField]
    private float height_;

    [SerializeField]
    private float projectile_speed_ = 5f;
    private Vector3 target_pos_;

    private bool is_crash_ = false;


    public override void activate()
    {
        if (!is_ready && !is_crash_)
        {
            transform.position = Vector3.Lerp(transform.position, target_pos_, Time.deltaTime * projectile_speed_);
        }

        if(Vector3.Distance(transform.position, target_pos_) <= Time.deltaTime * projectile_speed_)
        {
            transform.position = target_pos_;
            is_crash_ = true;
        }

        if (is_crash_)
        {
            GetComponent<Animator>().SetBool("is_end", is_crash_);
        }
    }

    public override void init()
    {
        target_pos_ = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y + height_, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!is_ready)
        {
            if (collision.tag != team_)
            {
                if (collision.tag == "Player" || collision.tag == "Monster")
                {
                    onHit(collision);
                }
            }
        }
    }

    public void onHit(Collider2D _collision)
    {
        _collision.GetComponent<Entity>().hitDamage(skill_data_.skill_damage[skill_level_]);
        is_crash_ = true;
    }

}
