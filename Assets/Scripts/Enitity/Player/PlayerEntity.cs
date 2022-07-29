using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    private float fire_damage_percent_ = 1f;
    public float fire_damage_percent { get => fire_damage_percent_; set => fire_damage_percent_ = value; }

    protected override void onDie()
    {
        Debug.Log("GameOver");
    }
}
