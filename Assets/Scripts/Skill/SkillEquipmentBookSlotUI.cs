using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEquipmentBookSlotUI : MonoBehaviour
{
    private int book_no_;
    private SkillEquipmentSkillSlotUI[] skill_slot_arr_;

    public void init()
    {
        skill_slot_arr_ = transform.GetComponentsInChildren<SkillEquipmentSkillSlotUI>();
        foreach (var slot in skill_slot_arr_)
        {
            slot.init();
        }
    }

    public void setBookNo(int _no)
    {
        book_no_ = _no;
    }

    public void updateSkillSlots()
    {
        for (int i = 0; i < skill_slot_arr_.Length; i++)
        {
            skill_slot_arr_[i].updateSkillSlot(i, book_no_);
        }
    }
}
