using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData.asset", menuName = "SkillData")]
public class SkillData : ScriptableObject
{
    public int skill_no;
    public Rarity skill_rarity;
    public GameObject projectile;
    public string skill_name;
    public Sprite skill_image;
    public int[] command;
    public int[] command_length;
    public float[] casting_range;
    public float[] projectile_speed;
    public float[] cool_time;
    public int[] skill_damage;
}