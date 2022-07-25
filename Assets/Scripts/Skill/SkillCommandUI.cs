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
    private Sprite[] rune_sprite_arr_;
    [SerializeField]
    private Transform skill_command_parent_;

    private bool condition_ = false;

    private Transform[] skill_command_tr_arr_;
    private Image[] skill_command_image_arr_;
    private const int MAX_COMMAND_SIZE_ = 10;
    private int[] cur_skill_command_arr_;

    private Vector3 curr_target_pos_ {get => (condition_) ? activate_target_tr_.position : unactivate_target_tr_.position;}

    private void Update()
    {
        updatePosition();
    }

    public void init()
    {
        skill_command_tr_arr_ = Utility.getChildsTransform(skill_command_parent_);
        skill_command_image_arr_ = skill_command_parent_.GetComponentsInChildren<Image>();
    }

    private void loadSkillCommand()
    {
        cur_skill_command_arr_ = SkillManager.instance.getCurrSkill().skill_data.command;
    }

    private void setSkillCommandSprite()
    {
        for (int i = 0; i < cur_skill_command_arr_.Length; i++)
        {
            skill_command_tr_arr_[i].gameObject.SetActive(true);
            skill_command_image_arr_[i].sprite = rune_sprite_arr_[cur_skill_command_arr_[i]];
        }
    }

    private void initSkillCommandSprite()
    {
        for (int i = 0; i < MAX_COMMAND_SIZE_; i++)
        {
            skill_command_tr_arr_[i].gameObject.SetActive(false);
        }
    }

    public void setCommandSprite()
    {
        initSkillCommandSprite();
        loadSkillCommand();
        setSkillCommandSprite();
    }

    public void updatePosition()
    {
        transform.position = Vector3.Lerp(transform.position, curr_target_pos_, Time.deltaTime * ui_move_speed_);
    }

    public void setCondition(bool _value)
    {
        condition_ = _value;
    }

}
