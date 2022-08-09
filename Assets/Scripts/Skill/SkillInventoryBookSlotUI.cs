using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventoryBookSlotUI : MonoBehaviour
{
    private SkillBook skill_book_;
    private int skill_book_no_;

    private SkillInventorySkillSlotUI[] skill_slot_arr_;

    public int skill_book_no { get => skill_book_no_; }

    public void init()
    {
        skill_slot_arr_ = transform.GetComponentsInChildren<SkillInventorySkillSlotUI>();
        foreach (var slot in skill_slot_arr_)
        {
            slot.init();
        }
    }

    public void setSkillBookNo(int _no)
    {
        skill_book_no_ = _no;
        for(int i = 0; i < skill_slot_arr_.Length; i++)
        {
            skill_slot_arr_[i].setBookSlot(skill_book_no_);
            skill_slot_arr_[i].setSlotNo(i);
        }
    }
}
