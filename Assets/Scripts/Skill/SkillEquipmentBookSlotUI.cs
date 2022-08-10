using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillEquipmentBookSlotUI : MonoBehaviour
{
    private int book_no_;
    private SkillEquipmentSkillSlotUI[] skill_slot_arr_;
    private Image skill_image_;

    public void init()
    {
        skill_slot_arr_ = transform.GetComponentsInChildren<SkillEquipmentSkillSlotUI>();
        skill_image_ = GetComponent<Image>();
        skill_image_.color = SkillManager.instance.getEquipmentBook(book_no_).skill_book_data.skill_book_color;
        foreach (var slot in skill_slot_arr_)
        {
            slot.init();
        }
    }

    private void Update()
    {
        skill_image_.color = SkillManager.instance.getEquipmentBook(book_no_).skill_book_data.skill_book_color;
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
