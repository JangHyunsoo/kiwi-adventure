using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    private Skill skill_ = null;
    private int slot_no_;

    [SerializeField]
    private Image skill_image_;

    private bool is_equipment_slot_ = false;

    public int slot_no { get => slot_no_; set => slot_no_ = value; }
    public bool is_equipment_slot { get => is_equipment_slot_; }
    public Skill skill { get => skill_; set => skill_ = value; }

    private void Update()
    {
        skill_ = SkillManager.instance.getSkill(slot_no_, is_equipment_slot);
        updateSkill();
    }

    private void setColor(float _alpha)
    {
        Color color = skill_image_.color;
        color.a = _alpha;
        skill_image_.color = color;
    }

    public void setupEquipmentSlot()
    {
        is_equipment_slot_ = true;
    }

    public bool getIsEquipmentSlot()
    {
        return is_equipment_slot_;
    }

    public void addSkill(Skill _skill)
    {
        skill_ = _skill;
        updateSkill();
    }

    public void updateSkill()
    {
        if (skill == null) clearSlot();
        else
        {
            skill_image_.sprite = skill_.skill_data.skill_image;
            if (skill_.is_known) setColor(1);
            else setColor(0.3f);
        }
    }

    public void clearSlot()
    {
        skill_ = null;
        skill_image_.sprite = null;
        setColor(1);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(skill_ != null)
        {
            DragSkillInventorySlot.instance.skill_slot = this;
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
        DragSkillInventorySlot.instance.skill_slot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragSkillInventorySlot.instance.skill_slot != null)
        {
            if (is_equipment_slot_ && !DragSkillInventorySlot.instance.skill_slot.skill.is_known)
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
                SkillManager.instance.updateSkillInfoCard(this);
            }
        }
    }

    private void ChangeSlot()
    {
        SkillManager.instance.swapSkillSlot(this, DragSkillInventorySlot.instance.skill_slot);
    }
}