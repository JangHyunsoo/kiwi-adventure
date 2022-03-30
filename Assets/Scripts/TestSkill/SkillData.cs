using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData.asset", menuName = "SkillData")]
public class SkillData : ScriptableObject
{
    public int skill_no;
    public string skill_name;
    public Sprite skill_image;
    public Sprite skill_icon;
    public Sprite projectile_sprite;
    public string command;
    public float cool_time;
    public GameObject projectile;
}
