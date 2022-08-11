using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoCardUI : MonoBehaviour
{
    private int slot_no_;
    private SkillSlotType slot_type_;
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
    private Text curr_skill_level_;

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
    [SerializeField]
    private Transform create_btn_;

    private void Update()
    {
        curr_skill_ = SkillManager.instance.getSkill(slot_no_, slot_type_);
        updateSkillInfo();
    }

    public void setSlotNo(int _slot_no, SkillSlotType _slot_type)
    {
        slot_no_ = _slot_no;
        slot_type_ = _slot_type;
        curr_skill_ = SkillManager.instance.getSkill(_slot_no, _slot_type);
    }

    public void updateSkillInfo()
    {
        if (curr_skill_ == null)
        {
            clearSkillInfo();
        }
        else
        {
            updateSkill();
        }
    }

    public void clearSkillInfo()
    {
        curr_skill_image_.sprite = null;
        curr_skill_name_.text = "null";
        curr_skill_cost_.text = "0";
        curr_skill_cooltime_.text = "0";
        curr_skill_damage_.text = "0";
        curr_skill_level_.text = "0";
        curr_skill_air_element_count_.text = "0";
        curr_skill_aqua_element_count_.text = "0";
        curr_skill_earth_element_count_.text = "0";
        curr_skill_fire_element_count_.text = "0";
        curr_skill_photon_element_count_.text = "0";
        curr_skill_element_dust_count_.text = "0";
        create_btn_.gameObject.SetActive(false);
    }

    private void updateSkill()
    {
        int curr_level = curr_skill_.level;

        curr_skill_image_.sprite = curr_skill_.skill_data.skill_image;
        curr_skill_name_.text = curr_skill_.skill_data.skill_name;
        curr_skill_cost_.text = curr_skill_.skill_data.skill_cost[curr_level].ToString();
        curr_skill_cooltime_.text = curr_skill_.skill_data.cool_time[curr_level].ToString();
        curr_skill_damage_.text = curr_skill_.skill_data.skill_damage[curr_level].ToString();
        curr_skill_level_.text = curr_level.ToString();
        curr_skill_air_element_count_.text = curr_skill_.skill_recipe_data.air_element_count.ToString();
        curr_skill_aqua_element_count_.text = curr_skill_.skill_recipe_data.aqua_element_count.ToString();
        curr_skill_earth_element_count_.text = curr_skill_.skill_recipe_data.earth_element_count.ToString();
        curr_skill_fire_element_count_.text = curr_skill_.skill_recipe_data.fire_element_count.ToString();
        curr_skill_photon_element_count_.text = curr_skill_.skill_recipe_data.photon_element_count.ToString();
        curr_skill_element_dust_count_.text = curr_skill_.skill_recipe_data.element_dust_count.ToString();
        create_btn_.gameObject.SetActive(curr_skill_.level == 0);
    }

    public void createSkill()
    {
        SkillManager.instance.createSkillBySlot(slot_no_);
        curr_skill_ = null;
    }
}
