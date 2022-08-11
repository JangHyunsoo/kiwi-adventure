using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillEquipmentBookSlotUI : MonoBehaviour
{
    private SkillSlotType slot_type_;
    private SkillEquipmentSkillSlotUI[] skill_slot_arr_;
    private Image skill_image_;

    public void init()
    {
        skill_slot_arr_ = transform.GetComponentsInChildren<SkillEquipmentSkillSlotUI>();
        skill_image_ = GetComponent<Image>();
        skill_image_.color = SkillManager.instance.getEquipmentBook(slot_type_).skill_book_data.skill_book_color;
        foreach (var slot in skill_slot_arr_)
        {
            slot.init();
        }
    }

    private void Update()
    {
        skill_image_.color = SkillManager.instance.getEquipmentBook(slot_type_).skill_book_data.skill_book_color;
    }

    public void setBookNo(SkillSlotType _slot_type)
    {
        slot_type_ = _slot_type;
    }

    public void updateSkillSlots()
    {
        for (int i = 0; i < skill_slot_arr_.Length; i++)
        {
            skill_slot_arr_[i].updateSkillSlot(i, slot_type_);
        }
    }
}
