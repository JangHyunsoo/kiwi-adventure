using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillInventoryBookSlotUI : MonoBehaviour, IPointerClickHandler
{
    private int skill_book_no_;
    private SkillInventorySkillSlotUI[] skill_slot_arr_;

    private Image skill_image_;

    public int skill_book_no { get => skill_book_no_; }

    public void init()
    {
        skill_slot_arr_ = transform.GetComponentsInChildren<SkillInventorySkillSlotUI>();
        skill_image_ = GetComponent<Image>();
        skill_image_.color = SkillManager.instance.getEquipmentBook(skill_book_no_).skill_book_data.skill_book_color;
        foreach (var slot in skill_slot_arr_)
        {
            slot.init();
        }
    }

    private void Update()
    {
        skill_image_.color = SkillManager.instance.getEquipmentBook(skill_book_no_).skill_book_data.skill_book_color;
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

    public void changeSkillBookData()
    {
        SkillManager.instance.getEquipmentBook(skill_book_no_).changeSkillBookDataRandom();
    }

    public void changeSkillOption()
    {
        SkillManager.instance.getEquipmentBook(skill_book_no_).changeSkillOption();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SkillManager.instance.updateSkillBookInfoCard(skill_book_no_);
        }
    }
}
