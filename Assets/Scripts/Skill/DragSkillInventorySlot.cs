using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSkillInventorySlot : MonoBehaviour
{
    static public DragSkillInventorySlot instance;

    private SkillSlot skill_slot_;
    public SkillSlot skill_slot { get => skill_slot_; set => skill_slot_ = value; }

    [SerializeField]
    private Image skill_image_;

    private void Start()
    {
        instance = this;
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
