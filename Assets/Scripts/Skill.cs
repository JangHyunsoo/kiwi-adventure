using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public string skill_name;
    public Sprite skill_image;
    public Sprite skill_icon;
    public string command;
    public float cool_time;
    public GameObject projectile;

    public virtual void activate(Transform _my_tr, Vector3 _target_pos) {}
}
