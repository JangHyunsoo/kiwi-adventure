using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoCard : MonoBehaviour
{
    private Skill curr_skill_;
    [SerializeField]
    private Image curr_skill_image_;
    [SerializeField]
    private Text curr_skill_name_;
    [SerializeField]
    private Text curr_skill_cost_;
    [SerializeField]
    private Text curr_skill_cooltime_;
    [SerializeField]
    private Text curr_skill_damage_;
    [SerializeField]
    private Text curr_skill_air_element_count_;
    [SerializeField]
    private Text curr_skill_aqua_element_count_;
    [SerializeField]
    private Text curr_skill_earth_element_count_;
    [SerializeField]
    private Text curr_skill_fire_element_count_;
    [SerializeField]
    private Text curr_skill_photon_element_count_;
    [SerializeField]
    private Text curr_skill_element_dust_count_;

    public void setSkill(Skill _skill)
    {
        curr_skill_ = _skill;
        curr_skill_image_.sprite = _skill.skill_data.skill_image;
        curr_skill_name_.text = _skill.skill_data.skill_name;
        curr_skill_cost_.text = _skill.skill_data.skill_cost.ToString();
        curr_skill_cooltime_.text = _skill.skill_data.cool_time.ToString();
        curr_skill_damage_.text = _skill.skill_data.skill_damage.ToString();
        curr_skill_air_element_count_.text = _skill.skill_recipe_data.air_element_count.ToString();
        curr_skill_aqua_element_count_.text = _skill.skill_recipe_data.aqua_element_count.ToString();
        curr_skill_earth_element_count_.text = _skill.skill_recipe_data.earth_element_count.ToString();
        curr_skill_fire_element_count_.text = _skill.skill_recipe_data.fire_element_count.ToString();
        curr_skill_photon_element_count_.text = _skill.skill_recipe_data.photon_element_count.ToString();
        curr_skill_element_dust_count_.text = _skill.skill_recipe_data.element_dust_count.ToString();
    }
}
