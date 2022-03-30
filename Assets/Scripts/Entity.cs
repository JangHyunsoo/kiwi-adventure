using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    protected Status status_data_;
    public Status status_data { get => status_data_; }

    protected int current_hp_;
    public int current_hp { get => current_hp_; set => current_hp_ = value; }

    private void Start()
    {
        init();
    }
    private void init()
    {
        current_hp = status_data_.max_hp;
    }
    public void hitDamage(int _damage)
    {
        current_hp -= _damage;
        if (current_hp <= 0) current_hp = 0;
    }
    public float getHpPersent()
    {
        return (float)current_hp / (float)status_data_.max_hp;
    }
}
