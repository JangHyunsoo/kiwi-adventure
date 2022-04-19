using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    private Skill skill_;

    [SerializeField]
    private Image skill_image_;
    private bool isKnown = false;

    private bool isEquipmentSlot = false;

    public Skill skill { get => skill_; set => skill_ = value; }

    private void Start()
    {
        
    }

    private void setColor(float _alpha)
    {
        Color color = skill_image_.color;
        color.a = _alpha;
        skill_image_.color = color;
    }

    public void setupEquipmentSlot()
    {
        isEquipmentSlot = true;
    }

    public bool getIsEquipmentSlot()
    {
        return isEquipmentSlot;
    }

    public void addSkill(Skill _skill)
    {
        skill_ = _skill;
        skill_image_.sprite = skill_.skill_data.skill_image;
        if (_skill.isKnown) setColor(1);
        else setColor(0.3f);
    }
    
    private void clearSlot()
    {
        skill_ = null;
        skill_image_.sprite = null;
        // setColor(0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(skill_ != null)
        {
            DragSlot.instance.skill_slot = this;
            DragSlot.instance.DragSetSkill(skill_image_);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (skill_ != null)
        {
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.setColor(0);
        DragSlot.instance.skill_slot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(DragSlot.instance.skill_slot != null)
        {
            ChangeSlot();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            SkillInventory.instance.updateSkillInfoCard(skill_);
        }
    }

    private void ChangeSlot()
    {
        Skill temp = skill;

        addSkill(DragSlot.instance.skill_slot.skill_);

        if(temp != null)
        {
            DragSlot.instance.skill_slot.addSkill(temp);
        }
        else
        {
            DragSlot.instance.skill_slot.clearSlot();
        }

        SkillInventory.instance.updateEquipmentSlot();
    }
}
