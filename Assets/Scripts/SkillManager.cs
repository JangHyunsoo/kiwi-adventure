using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static SkillManager _instance;
    public static SkillManager instance
    {
        get
        {
            if (_instance == null) { return null; }
            else { return _instance; }
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField]
    private SkillInventoryUI skill_inventory_ui_;
    [SerializeField]
    private SkillInfoCardUI skill_info_card_;
    [SerializeField]
    private SkillSliderUI skill_slider_ui_;
    [SerializeField]
    private SkillCommandUI skill_command_ui_;

    [SerializeField]
    private SkillInventory skill_inventory_;

    private int curr_skill_index_ = 0;
    public int curr_skill_index { get => curr_skill_index_; }
    public int have_skill_count { get => skill_inventory_.have_skill_slot_count; }
    public int eqiupment_skill_count { get => skill_inventory_.eqiupment_skill_slot_count; }

    public void init()
    {
        skill_inventory_.init();
        skill_inventory_ui_.init();
        skill_slider_ui_.init();
        skill_command_ui_.init();
        updateSkillUI();
    }

    public void setSkillInventoryActivate(bool _condition)
    {
        skill_inventory_ui_.setActivate(_condition);
    }

    public void addSkill(Skill _skill)
    {
        skill_inventory_.addSkillToHave(_skill);
    }

    public void updateEquipmentSlot()
    {
        skill_slider_ui_.updateSkillImage();
    }

    public void updateSkillInfoCard(SkillSlot _slot)
    {
        skill_info_card_.setSkill(_slot);
    }

    public void moveCurrSkillCursor(int _idx)
    {
        curr_skill_index_ = _idx;
    }

    public void castingSkillAction(int _key_code)
    {
        skill_slider_ui_.rotateCurrntSkill(_key_code);
    }

    public Skill getEquipmentSkill(int _idx)
    {
        return skill_inventory_.getEquipmentSkill(_idx);
    }

    public Skill getCurrSkill()
    {
        return skill_inventory_.getEquipmentSkill(curr_skill_index_);
    }

    public Skill searchSkillMaxLevel(int _no)
    {
        return skill_inventory_.searchSkillMaxLevel(_no);
    }

    public void swapSkillSlot(SkillSlot _one, SkillSlot _other)
    {
        skill_inventory_.swapSkillSlot(_one, _other);
    }

    public Skill getSkill(int _no, bool _is_equipment)
    {
        return skill_inventory_.getSkill(_no, _is_equipment);
    }

    public void setSkill(Skill _skill, int _no, bool _is_equipment)
    {
        skill_inventory_.setSkill(null, _no, _is_equipment);
    }

    public void createSkillBySlot(int _no, bool _is_equipment)
    {
        skill_inventory_.createSkill(_no, _is_equipment);
    }

    public void updateSkillUI()
    {
        skill_inventory_ui_.updateSkillSlot();
        skill_slider_ui_.updateSkillImage();
        skill_info_card_.updateSkillInfo();
    }
}