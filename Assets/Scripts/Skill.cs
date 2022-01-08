using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public string skill_name;
    public string command;
    public float cool_time;
    public Projectile projectile;

    public virtual void activate(Vector3 _pos) {}
}
