using UnityEngine;

public class Effect
{
    protected bool is_tick_;
    protected float value_;
    protected float cur_tick_time_ = 0f;

    public Effect(bool _is_tick, float _value)
    {
        is_tick_ = _is_tick;
        value_ = _value;
    }

    public virtual void onetimeActivate(Entity _entity, int _stack)
    {
        cur_tick_time_ = 0f;
    }

    public virtual void sequenceActivate(Entity _entity, int _stack)
    {
    }
}

public class TickHpEffect : Effect
{
    public TickHpEffect(bool _is_tick, float _value) : base(_is_tick, _value) { }

    public override void sequenceActivate(Entity _entity, int _stack)
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

    public override void onetimeActivate(Entity _entity, int _stack)
    {
        base.onetimeActivate(_entity, _stack);
        _entity.slow_value *= Mathf.Pow(value_, _stack);
    }

    public override void sequenceActivate(Entity _entity, int _stack)
    {
        cur_tick_time_ += Time.deltaTime;

        if (cur_tick_time_ > 3f)
        {
            _entity.slow_value /= value_;
            cur_tick_time_ -= 3f;
        }
    }
}

public class CoolTimeEffect : Effect
{
    public CoolTimeEffect(bool _is_tick, float _value) : base(_is_tick, _value) { }

    public override void sequenceActivate(Entity _entity, int _stack)
    {
        _entity.cooltime_value *= value_;
    }
}