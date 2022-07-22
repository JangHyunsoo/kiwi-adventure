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

    private bool is_tick_ = false;

    public override void init()
    {

    }

    public override void activate()
    {
        is_tick_ = false;
        curr_damage_delay_time += Time.deltaTime;

        // when time out, destory obejct
        if (hit_times_ <= curr_hit_times_)
        {
            Destroy(gameObject);
            return;
        }

        if (damage_delay_time_ <= curr_damage_delay_time)
        {
            is_tick_ = true;
            curr_hit_times_++;
            curr_damage_delay_time = 0f;
        }

        if (is_tick_)
        {
            tick();
        }
    }

    protected virtual void tick()
    {

    }
}
