using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject have_skill_slot_parent_;
    [SerializeField]
    private GameObject equipment_book_slot_parent_;

    [SerializeField]
    private SkillInventoryBookSlotUI[] equipment_book_slot_arr_;
    [SerializeField]
    private SkillInventorySkillSlotUI[] have_skill_slot_arr_;

    private bool is_activate_ = false;

    public void init()
    {
        setupEquipmentSlot();
        setupHaveSlot();
    }

    private void setupHaveSlot()
    {
        have_skill_slot_arr_ = have_skill_slot_parent_.GetComponentsInChildren<SkillInventorySkillSlotUI>();

        for (int i = 0; i < have_skill_slot_arr_.Length; i++)
        {
            have_skill_slot_arr_[i].init();
            have_skill_slot_arr_[i].setSlotNo(i);
        }
    }

    private void setupEquipmentSlot()
    {
        equipment_book_slot_arr_ = equipment_book_slot_parent_.GetComponentsInChildren<SkillInventoryBookSlotUI>();

        for (int i = 0; i < equipment_book_slot_arr_.Length; i++)
        {
            equipment_book_slot_arr_[i].init();
            equipment_book_slot_arr_[i].setSkillBookNo((SkillSlotType)i);
        }
    }

    public void setActivate(bool _condition)
    {
        is_activate_ = _condition;
        gameObject.SetActive(_condition);
    }
}
