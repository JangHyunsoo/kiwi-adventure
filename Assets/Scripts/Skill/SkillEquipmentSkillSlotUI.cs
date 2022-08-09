using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillEquipmentSkillSlotUI : MonoBehaviour
{
    private Image background_image_;
    public Image background_image { get => background_image_; }
    private Image icon_image_;
    public Image icon_image { get => icon_image_; }
    private Image cool_item_image_;
    public Image cool_item_image { get => cool_item_image_; }
    private Image bolder_line_image_;
    public Image bolder_line_image { get => bolder_line_image_; }

    public void init()
    {
        var images = GetComponentsInChildren<Image>();
        background_image_ = images[0];
        icon_image_ = images[1];
        cool_item_image_ = images[2];
        bolder_line_image_ = images[3];
    }

    public void updateSkillSlot(int _slot_no, int _book_no)
    {
        Skill curr_skill = SkillManager.instance.getEquipmentSkill(_slot_no, _book_no);

        if (_slot_no == SkillManager.instance.curr_skill_index && _book_no == SkillManager.instance.curr_book_index)
        {
            bolder_line_image_.color = Color.green;
        }
        else
        {
            bolder_line_image_.color = Color.gray;
        }

        if (curr_skill != null)
        {
            icon_image.color = Color.white;
            icon_image_.sprite = curr_skill.skill_data.skill_image;
            cool_item_image_.fillAmount = curr_skill.getCooltiemAmount();
        }
        else
        {
            icon_image.color = Color.clear;
            icon_image_.sprite = null;
            cool_item_image_.fillAmount = 0f;
        }
    }
}
