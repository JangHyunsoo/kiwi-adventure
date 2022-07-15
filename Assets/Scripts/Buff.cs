using UnityEngine;

public class Buff
{
    private string name_;
    public string name { get => name_; }
    private double during_time_;
    public Effect[] effect_list_;
    private int cur_stack_ = 0;
    public int cur_stack { get => cur_stack_; }
    private int buff_stack_;
    private float cur_time_ = 0f;

    public Buff(string _name, int _stack, double _during_time, params Effect[] _effects)
    {
        name_ = _name;
        during_time_ = _during_time;
        buff_stack_ = _stack;
        effect_list_ = _effects;
    }

    public void onetimeActivate(Entity _entity)
    {
        cur_time_ = 0f;
        cur_stack_ += buff_stack_;

        foreach (var _effect in effect_list_)
        {
            _effect.onetimeActivate(_entity, buff_stack_);
        }
    }

    public bool sequenceActivate(Entity _entity)
    {
        cur_time_ += Time.deltaTime;

        if (during_time_ <= cur_time_)
        {
            cur_time_ -= (float)during_time_;
            cur_stack_--;
        }

        foreach (var _effect in effect_list_)
        {
            _effect.sequenceActivate(_entity, cur_stack_);
        }

        return cur_stack_ == 0;
    }


    public void increaseStack(int _value)
    {
        cur_stack_ += _value;
    }

    public void increaseStack(Buff _buff)
    {
        cur_time_ = 0f;
        cur_stack_ += _buff.buff_stack_;
    }
}

public class Burn : Buff
{
    public Burn(int _stack) : base("Burn", _stack, 3d, new TickHpEffect(1), new SpeedEffect(0.97f)) { }
}

public class HpOverPower : Buff
{
    public HpOverPower(int _value) : base("HpOverPower", 1, -1d, new MaxHpEffect(_value)) { } 
}



