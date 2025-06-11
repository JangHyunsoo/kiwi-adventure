using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSkillInventorySlot : MonoBehaviour
{
    static public DragSkillInventorySlot instance;

    private int slot_no_;
    private SkillSlotType slot_type_;

    [SerializeField]
    private Image skill_image_;

    public int slot_no { get => slot_no_; }
    public SkillSlotType slot_type { get => slot_type_; }

    private void Start()
    {
        instance = this;
    }

    public void setSlotNo(int _slot_no)
    {
        slot_no_ = _slot_no;
    }

    public void setBookNo(SkillSlotType _slot_type)
    {
        slot_type_ = _slot_type;
    }

    public Skill getSkill()
    {
        return SkillManager.instance.getSkill(slot_no_, slot_type_);
    }

    public void DragSetSkill(Image _skill_image)
    {
        skill_image_.sprite = _skill_image.sprite;
        setColor(1);
    }

    public void setColor(float _alpha)
    {
        Color color = skill_image_.color;
        color.a = _alpha;
        skill_image_.color = color;
    }
}
