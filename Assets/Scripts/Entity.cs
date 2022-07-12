using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    protected Status status_data_;
    public Status status_data { get => status_data_; set => status_data_ = value; }

    [SerializeField]
    protected int current_hp_;
    public int current_hp { get => current_hp_; set => current_hp_ = value; }

    protected float current_speed_;
    public float current_speed { get => current_speed_; set => current_speed_ = value; }

    protected float cooltime_value_;
    public float cooltime_value { get => cooltime_value_; set => cooltime_value_ = value; }


    private void Awake()
    {
        init();
    }
    protected virtual void init()
    {
        current_hp = status_data_.max_hp;
    }
    public void hitDamage(int _damage)
    {
        current_hp -= _damage;
        if (current_hp <= 0)
        {
            current_hp = 0;
            onDie();
        }
    }
    public float getHpPersent()
    {
        return (float)current_hp / (float)status_data_.max_hp;
    }
    protected virtual void onDie() 
    { 

    }
}
