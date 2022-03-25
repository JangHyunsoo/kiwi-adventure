using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFieldProjectile : Projectile
{
    private double delay_time_ = 5f;
    private double curr_delay_time_ = 0f;

    private SpriteRenderer sprite_renderer;

    public override void init()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
        setAlpha(0f);
    }
    public override void activate()
    {
        curr_delay_time_ += Time.deltaTime;
        setAlpha((float)(1 - (curr_delay_time_ / delay_time_)));

        if (delay_time_ <= curr_delay_time_)
        {
            Destroy(gameObject);
        }
    }


    private void setAlpha(float _alpha)
    {
        Color color = sprite_renderer.color;
        color.a = _alpha;
        sprite_renderer.color = color;
    }
}
