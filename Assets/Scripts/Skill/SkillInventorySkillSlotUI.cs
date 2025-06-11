using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillInventorySkillSlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    private Skill skill_ = null;
    private int slot_no_;
    private SkillSlotType slot_type_ = SkillSlotType.HAVE;
    private Image skill_image_;

    public int slot_no { get => slot_no_; }
    public SkillSlotType slot_type { get => slot_type_; }
    public bool is_equipment_slot { get => slot_type_ != SkillSlotType.HAVE; }
    public Skill skill { get => skill_; }

    public void init()
    {
        skill_image_ = GetComponentsInChildren<Image>()[2];
    }

    private void Update()
    {
        skill_ = SkillManager.instance.getSkill(slot_no_, slot_type_);
        updateSkill();
    }

    private void updateSkill()
    {
        if (skill == null) clearSlot();
        else
        {
            skill_image_.sprite = skill_.skill_data.skill_image;
            if (skill_.is_known) setColor(1);
            else setColor(0.3f);
        }
    }

    private void clearSlot()
    {
        skill_ = null;
        skill_image_.sprite = null;
        setColor(0);
    }

    private void setColor(float _alpha)
    {
        Color color = skill_image_.color;
        color.a = _alpha;
        skill_image_.color = color;
    }

    public void setSlotNo(int _no)
    {
        slot_no_ = _no;
    }

    public void setBookSlot(SkillSlotType _slot_type)
    {
        slot_type_ = _slot_type;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(skill_ != null)
        {
            DragSkillInventorySlot.instance.setSlotNo(slot_no_);
            DragSkillInventorySlot.instance.setBookNo(slot_type_);
            DragSkillInventorySlot.instance.DragSetSkill(skill_image_);
            DragSkillInventorySlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (skill_ != null)
        {
            DragSkillInventorySlot.instance.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSkillInventorySlot.instance.setColor(0);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Skill curr_skill = DragSkillInventorySlot.instance.getSkill();

        if (curr_skill != null)
        {
            if (is_equipment_slot && !curr_skill.is_known)
            {
                return;
            }
            else
            {
                ChangeSlot();
            }
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(skill_ != null)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                SkillManager.instance.updateSkillInfoCard(slot_no_, slot_type_);
            }
        }
    }

    private void ChangeSlot()
    {
        SkillManager.instance.swapSkillSlot(slot_no_, slot_type_, DragSkillInventorySlot.instance.slot_no, DragSkillInventorySlot.instance.slot_type);
    }
}