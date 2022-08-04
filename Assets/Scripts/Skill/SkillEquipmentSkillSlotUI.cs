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

    public void setIconImageSprite(Sprite _sprite)
    {
        icon_image_.sprite = _sprite;
    }

    public void setBolderLineColor(Color _color)
    {
        bolder_line_image_.color = _color;
    }

    public void setCoolTimeValue(float _value)
    {
        cool_item_image_.fillAmount = _value;
    }

}
