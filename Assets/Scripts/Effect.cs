using UnityEngine;


public class Effect
{
    protected bool is_tick_;
    protected float value_;

    public Effect(bool _is_tick, float _value)
    {
        is_tick_ = _is_tick;
        value_ = _value;
    }

    public virtual void activate(Entity _entity, int _stack)
    {
    }
}

public class TickHpEffect : Effect
{
    private float cur_tick_time_ = 0f;

    public TickHpEffect(bool _is_tick, float _value) : base(_is_tick, _value) { }

    public override void activate(Entity _entity, int _stack)
    {
        cur_tick_time_ += Time.deltaTime;

        if(cur_tick_time_ > 1f)
        {
            _entity.hitDamage((int)(value_ * _stack));
            cur_tick_time_ -= 1f;
        }
    }
}

public class SpeedEffect : Effect
{
    public SpeedEffect(bool _is_tick, float _value) : base(_is_tick, _value) { }

    public override void activate(Entity _entity, int _stack)
    {
        _entity.current_speed *= value_;
        
    }
}

public class CoolTimeEffect : Effect
{
    public CoolTimeEffect(bool _is_tick, float _value) : base(_is_tick, _value) { }

    public override void activate(Entity _entity, int _stack)
    {
        _entity.cooltime_value *= value_;
    }
}