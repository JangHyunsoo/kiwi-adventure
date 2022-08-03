using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData.asset", menuName = "SkillData")]
public class SkillData : ScriptableObject
{
    public int skill_no;
    public Rarity skill_rarity;
    public string skill_name;
    public int[] command;
    public float cool_time;
    public float casting_range;
    public int skill_cost;
    public int skill_damage;
    public float projectile_speed;
    public ProjectileType projectile_type;
    public float projectile_size;
    public Sprite skill_image;
    public Sprite skill_icon;
    public Sprite projectile_sprite;
}