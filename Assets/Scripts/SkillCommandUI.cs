using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillCommandUI : MonoBehaviour
{
    [SerializeField]
    private float ui_move_speed_ = 5f;
    [SerializeField]
    private Transform activate_target_tr_;
    [SerializeField]
    private Transform unactivate_target_tr_;
    [SerializeField]
    private Sprite[] rune_sprite_list_;
    [SerializeField]
    private Transform skill_command_parent_;

    private bool condition_ = false;

    private Transform[] skill_command_tr_list_;
    private Image[] skill_command_image_list_;
    private const int MAX_COMMAND_SIZE_ = 10;
    private int[] cur_skill_command_;

    private void Update()
    {
        updatePosition(condition_);
    }


    public void init()
    {
        skill_command_tr_list_ = Utility.getChildsTransform(skill_command_parent_);
        skill_command_image_list_ = skill_command_parent_.GetComponentsInChildren<Image>();
    }

    private void loadSkillData()
    {
        cur_skill_command_ = SkillInventory.instance.getCurrSkill().skill_data.command;
    }

    private void setSkillCommandSprite()
    {
        for (int i = 0; i < cur_skill_command_.Length; i++)
        {
            skill_command_tr_list_[i].gameObject.SetActive(true);
            skill_command_image_list_[i].sprite = rune_sprite_list_[cur_skill_command_[i]];
        }
    }

    private void initSkillCommandSprite()
    {
        for (int i = 0; i < MAX_COMMAND_SIZE_; i++)
        {
            skill_command_tr_list_[i].gameObject.SetActive(false);
        }
    }

    public void setCommandSprite()
    {
        initSkillCommandSprite();
        loadSkillData();
        setSkillCommandSprite();
    }

    public void updatePosition(bool _condition)
    {
        var target = (_condition) ? activate_target_tr_ : unactivate_target_tr_;
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * ui_move_speed_);
    }

    public void setCondition(bool _value)
    {
        condition_ = _value;
    }

}
