public class Perk 
{
    private string name_;
    public string name { get => name_; }
    private int max_stack_;
    public int max_stack { get => max_stack_; }
    private int cur_stack_;
    public int cur_stack { get => cur_stack_; }
    private float value_;
    public float value { get => value; }


    public Perk(string _name, int _max_stack, float _value)
    {
        name_ = _name;
        max_stack_ = _max_stack;
        cur_stack_ = 0;
        value_ = _value;
    }

    public virtual void activate() {}

    public void addStack()
    {
        cur_stack_++;
        activate();
    }
}

public class FireBasePerk : Perk
{
    public FireBasePerk(string _name, int _max_stack, float _value) : base(_name, _max_stack, _value) {}

    public override void activate()  
    {
        PlayerManager.instance.player.fire_damage_percent = 1f + (cur_stack * value);
    }
}
