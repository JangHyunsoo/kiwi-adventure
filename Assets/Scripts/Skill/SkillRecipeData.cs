using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillRecipeData : ScriptableObject
{
    public SkillData skill_data;
    public int air_element_count;
    public int aqua_element_count;
    public int earth_element_count;
    public int fire_element_count;
    public int photon_element_count;
    public int element_dust_count;
    public int[] ToArray()
    {
        return new int[6] { air_element_count, aqua_element_count, earth_element_count, 
            fire_element_count, photon_element_count, element_dust_count };
    }
}
