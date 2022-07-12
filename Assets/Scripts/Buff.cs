using UnityEngine;


public class Buff
{
    private string name_;
    public string name { get => name_; }
    private double during_time_;
    private Effect[] effect_list_;
    private int max_stack_;
    private int stack_;
    private float cur_time_ = 0f;
    private bool activated_ = false;

    public Buff(string _name, int _stack, double _during_time, params Effect[] _effects)
    {
        name_ = _name;
        during_time_ = _during_time;
        stack_ = _stack;
        effect_list_ = _effects;
    }

    public virtual bool activate(Entity _entity)
    {
        cur_time_ += Time.deltaTime;


        if(during_time_ <= cur_time_)
        {
            cur_time_ -= (float)during_time_;
            stack_--;
            Debug.Log(stack_);
        }

        foreach (var _effect in effect_list_)
        {
            _effect.activate(_entity, stack_);
        }

        return stack_ == 0;
    }

    public void increaseStack(int _value)
    {
        stack_ += _value;
    }

    public void increaseStack(Buff _buff)
    {
        stack_ += _buff.stack_;
    }
}

public class Burn : Buff
{
    public Burn(int _stack) : base("Burn", _stack, 3d, new TickHpEffect(true, 1), new SpeedEffect(false, 0.1f)) {}

}




