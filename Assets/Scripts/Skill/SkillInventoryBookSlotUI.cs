using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillInventoryBookSlotUI : MonoBehaviour, IPointerClickHandler
{
    private SkillSlotType slot_type_;
    private SkillInventorySkillSlotUI[] skill_slot_arr_;

    private Image skill_image_;

    public SkillSlotType book_type { get => slot_type_; }

    public void init()
    {
        skill_slot_arr_ = transform.GetComponentsInChildren<SkillInventorySkillSlotUI>();
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

    public void setSkillBookNo(SkillSlotType _book_type)
    {
        slot_type_ = _book_type;
        for(int i = 0; i < skill_slot_arr_.Length; i++)
        {
            skill_slot_arr_[i].setBookSlot(_book_type);
            skill_slot_arr_[i].setSlotNo(i);
        }
    }

    public void changeSkillBookData()
    {
        SkillManager.instance.getEquipmentBook(slot_type_).changeSkillBookDataRandom();
    }

    public void changeSkillOption()
    {
        SkillManager.instance.getEquipmentBook(slot_type_).changeSkillOption();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SkillManager.instance.updateSkillBookInfoCard(slot_type_);
        }
    }
}
