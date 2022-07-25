using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData.asset", menuName = "SkillData")]
public class SkillData : ScriptableObject
{
    public int skill_no;
    public Rarity skill_rarity;
    public string skill_name;
    public Sprite skill_image;
    public Sprite skill_icon;
    public Sprite projectile_sprite;
    public int[] command;
    public float cool_time;
    public int skill_cost;
    public int skill_damage;
    public GameObject projectile;
}