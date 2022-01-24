using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillEquipSlot : MonoBehaviour
{
    private Image image_;
    private Skill skill_;

    void Start()
    {
        image_ = GetComponent<Image>();
    }

    public void updateSlot(Skill _skill)
    {
        skill_ = _skill;
        image_.sprite = skill_.skill_icon;
        setColor(1);
    }
    public void clearSlot()
    {
        skill_ = null;
        // setColor(0);
    }
    private void setColor(float _alpha)
    {
        Color color = image_.color;
        color.a = _alpha;
        image_.color = color;
    }
}
