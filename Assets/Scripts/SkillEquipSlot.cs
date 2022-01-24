using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillEquipSlot : MonoBehaviour
{
    [SerializeField]
    private Image image_;
    private Skill skill_;
    private Sprite none_sprite_;

    void Start()
    {
        none_sprite_ = image_.sprite;
    }

    public void updateSlot(Skill _skill)
    {
        skill_ = _skill;
        image_.sprite = skill_.skill_icon;
    }
    public void clearSlot()
    {
        skill_ = null;
        image_.sprite = null;
    }
    private void setColor(float _alpha)
    {
        Color color = image_.color;
        color.a = _alpha;
        image_.color = color;
    }
}
