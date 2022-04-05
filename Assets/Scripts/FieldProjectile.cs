using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldProjectile : Projectile
{
    [SerializeField]
    private double damage_delay_time_ = 1f;
    private double curr_damage_delay_time = 1f;
    [SerializeField]
    private int hit_times_ = 1;
    private int curr_hit_times_ = 0;

    private bool isTick = false;

    public override void init()
    {

    }

    public override void activate()
    {
        isTick = false;
        curr_damage_delay_time += Time.deltaTime;

        if (hit_times_ <= curr_hit_times_)
        {
            Destroy(gameObject);
        }

        if (damage_delay_time_ <= curr_damage_delay_time)
        {
            isTick = true;
            curr_hit_times_++;
            curr_damage_delay_time = 0f;
        }
    }

    protected virtual void tick()
    {

    }
}
