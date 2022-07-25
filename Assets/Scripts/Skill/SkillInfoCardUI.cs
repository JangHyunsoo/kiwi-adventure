using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoCardUI : MonoBehaviour
{
    private SkillSlot curr_slot_;
    public SkillSlot curr_slot { get => curr_slot_; }
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

    public void setSkill(SkillSlot _slot)
    {
        curr_slot_ = _slot;
        updateSkillInfo();
    }

    public void updateSkillInfo()
    {
        if(curr_slot.skill == null)
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
        curr_skill_image_.sprite = curr_slot_.skill.skill_data.skill_image;
        curr_skill_name_.text = curr_slot_.skill.skill_data.skill_name;
        curr_skill_cost_.text = curr_slot_.skill.skill_data.skill_cost.ToString();
        curr_skill_cooltime_.text = curr_slot_.skill.skill_data.cool_time.ToString();
        curr_skill_damage_.text = curr_slot_.skill.skill_data.skill_damage.ToString();
        curr_skill_level_.text = curr_slot_.skill.level.ToString();
        curr_skill_air_element_count_.text = curr_slot_.skill.skill_recipe_data.air_element_count.ToString();
        curr_skill_aqua_element_count_.text = curr_slot_.skill.skill_recipe_data.aqua_element_count.ToString();
        curr_skill_earth_element_count_.text = curr_slot_.skill.skill_recipe_data.earth_element_count.ToString();
        curr_skill_fire_element_count_.text = curr_slot_.skill.skill_recipe_data.fire_element_count.ToString();
        curr_skill_photon_element_count_.text = curr_slot_.skill.skill_recipe_data.photon_element_count.ToString();
        curr_skill_element_dust_count_.text = curr_slot_.skill.skill_recipe_data.element_dust_count.ToString();
        create_btn_.gameObject.SetActive(curr_slot_.skill.level == 0);
    }

    public void createSkill()
    {
        SkillSlot curr_slot = curr_slot_;
        Skill curr_skill = curr_slot_.skill;

        if (!ItemInventory.instance.checkItems(curr_skill.skill_recipe_data.toDictionary()))
        {
            Debug.Log("cannot create skill");
        }
        else
        {
            ItemInventory.instance.useItems(curr_skill.skill_recipe_data.toDictionary());
            Skill max_skill = SkillManager.instance.searchSkillMaxLevel(curr_skill.skill_data.skill_no);
            if (curr_skill == max_skill)
            {
                curr_skill.level++;
            }
            else
            {
                max_skill.level++;
                curr_slot.clearSlot();
            }
            Debug.Log("create " + curr_skill.skill_data.skill_name);
        }
        SkillManager.instance.updateSkillUI();
    }
}
