using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private Skill skill_;

    [SerializeField]
    private Image skill_image_;

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

    public void addSkill(Skill _skill)
    {
        skill_ = _skill;
        skill_image_.sprite = skill_.skill_image;
        setColor(1);
    }
    
    private void clearSlot()
    {
        skill_ = null;
        skill_image_.sprite = null;
        // setColor(0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin");
        if(skill_ != null)
        {
            DragSlot.instance.skill_slot = this;
            DragSlot.instance.DragSetSkill(skill_image_);
            Vector3 nowpos = eventData.position;
            nowpos.z = -1f;
            DragSlot.instance.transform.position = nowpos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (skill_ != null)
        {
            Vector3 nowpos = eventData.position;
            nowpos.z = -1f;
            DragSlot.instance.transform.position = nowpos;
            
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.setColor(0);
        DragSlot.instance.skill_slot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        if(DragSlot.instance.skill_slot != null)
        {
            ChangeSlot();
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
    }
}
