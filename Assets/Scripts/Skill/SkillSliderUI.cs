using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSliderUI : MonoBehaviour
{
    private float rotate_angle_;
    private Quaternion target_rotation_;

    [SerializeField]
    private float move_speed_ = 5f;
    [SerializeField]
    private float scale_speed_ = 5f;
    [SerializeField]
    private float color_speed_ = 8f;

    [SerializeField]
    private Sprite null_skill_sprite_;

    private const int SKILL_SIZE_ = 5;
    private const int SLOT_SIZE_ = 8;


    private int front_slot_index_ = 4;
    private int end_slot_index_ = 3;

    private int cur_pos_index_ = 0;
    private int cur_skill_index_ = 0;

    private int[] real_idx_pos_arr_ = { 0, 1, 2, 3, 7 };

    [SerializeField]
    private Transform skill_slot_image_parent_;
    [SerializeField]
    private Transform skill_slot_pos_parent_;

    private Transform[] skill_slot_image_tr_arr_;
    private Transform[] skill_slot_pos_tr_arr_;
    private SkillSliderSlotUI[] skill_slot_image_cp_arr_;

    [SerializeField]
    private Color normal_bolder_line_color_;
    [SerializeField]
    private Color curr_bolder_line_color_;

    public void init()
    {
        skill_slot_image_tr_arr_ = Utility.getChildsTransform(skill_slot_image_parent_);
        skill_slot_pos_tr_arr_ = Utility.getChildsTransform(skill_slot_pos_parent_);
        initSkillSlot();
        skill_slot_pos_parent_.rotation = Quaternion.Euler(0, 0, -45);
        target_rotation_ = skill_slot_pos_parent_.rotation;
    }

    private void initSkillSlot()
    {
        skill_slot_image_cp_arr_ = skill_slot_image_parent_.GetComponentsInChildren<SkillSliderSlotUI>();

        foreach (SkillSliderSlotUI slot in skill_slot_image_cp_arr_)
        {
            slot.init();
        }
    }

    private void Update()
    {
        int target_skill_index = SkillManager.instance.curr_skill_index;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (target_skill_index == 0)
            {
                target_skill_index = SKILL_SIZE_ - 1;
            }
            else
            {
                target_skill_index--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (target_skill_index == SKILL_SIZE_)
            {
                target_skill_index = 0;
            }
            else
            {
                target_skill_index++;
            }
        }

        rotateCurrntSkill(target_skill_index);
        updateSkillImage();
        updateSkillSlotPos();
        updateScale();
        updateBolderLine();
        rotateCircle();
    }

    private void updateSkillSlotPos()
    {
        for (int i = 0; i < SKILL_SIZE_; i++)
        {
            skill_slot_image_tr_arr_[i].position = skill_slot_pos_tr_arr_[real_idx_pos_arr_[i]].position;
        }
    }

    public void updateSkillImage()
    {
        for (int i = 0; i < SKILL_SIZE_; i++)
        {
            var skill = SkillManager.instance.getEquipmentSkill(i);
            if (skill == null)
            {
                skill_slot_image_cp_arr_[i].setIconImageSprite(null_skill_sprite_);
            }
            else
            {
                skill_slot_image_cp_arr_[i].setIconImageSprite(skill.skill_data.skill_icon);
            }
        }
    }

    private void rotateCircle()
    {
        skill_slot_pos_parent_.rotation = Quaternion.Lerp(skill_slot_pos_parent_.rotation, target_rotation_, Time.deltaTime * move_speed_);
    }

    private void updateScale()
    {
        for (int i = 0; i < SKILL_SIZE_; i++)
        {
            var cur_image = skill_slot_image_tr_arr_[i];
            if (cur_skill_index_ == i)
            {
                cur_image.localScale = Vector3.Lerp(cur_image.localScale, Vector3.one, Time.deltaTime * scale_speed_);
            }
            else
            {
                cur_image.localScale = Vector3.Lerp(cur_image.localScale, Vector3.one * 0.75f, Time.deltaTime * scale_speed_);
            }
        }
    }

    private void updateBolderLine()
    {
        for (int i = 0; i < SKILL_SIZE_; i++)
        {
            var cur_slot = skill_slot_image_cp_arr_[i];
            if (cur_skill_index_ == i)
            {
                cur_slot.setBolderLineColor(Color.Lerp(cur_slot.bolder_line_image.color, curr_bolder_line_color_, Time.deltaTime * color_speed_));
            }
            else
            {
                cur_slot.setBolderLineColor(Color.Lerp(cur_slot.bolder_line_image.color, normal_bolder_line_color_, Time.deltaTime * color_speed_));
            }
        }
    }

    private void rotateNext()
    {
        var new_front_idx = (front_slot_index_ - 1) % SKILL_SIZE_;
        if (new_front_idx < 0) new_front_idx += SKILL_SIZE_;

        if (cur_pos_index_ - real_idx_pos_arr_[front_slot_index_] == 1)
        {
            var new_front_real_pos = (real_idx_pos_arr_[front_slot_index_] - 1) % SLOT_SIZE_;
            if (new_front_real_pos < 0) new_front_real_pos += SLOT_SIZE_;
            real_idx_pos_arr_[new_front_idx] = new_front_real_pos;
            front_slot_index_ = new_front_idx;
            end_slot_index_ = (end_slot_index_ - 1) % SKILL_SIZE_;
            if (end_slot_index_ < 0)
            {
                end_slot_index_ += SKILL_SIZE_;
            }
        }
        else if (cur_pos_index_ == 0 && real_idx_pos_arr_[front_slot_index_] == (SLOT_SIZE_ - 1))
        {
            real_idx_pos_arr_[new_front_idx] = 6;
            front_slot_index_ = new_front_idx;
            end_slot_index_ = (end_slot_index_ - 1) % SKILL_SIZE_;
            if (end_slot_index_ < 0)
            {
                end_slot_index_ += SKILL_SIZE_;
            }
        }

        cur_pos_index_ = (cur_pos_index_ - 1) % SLOT_SIZE_;
        cur_skill_index_ = (cur_skill_index_ - 1) % SKILL_SIZE_;

        if (cur_pos_index_ < 0)
        {
            cur_pos_index_ += SLOT_SIZE_;
        }

        if (cur_skill_index_ < 0)
        {
            cur_skill_index_ += SKILL_SIZE_;
        }

        target_rotation_ = Quaternion.Euler(new Vector3(0, 0, target_rotation_.eulerAngles.z - 45));
    }

    private void rotatePrivious()
    {
        var new_end_idx = (end_slot_index_ + 1) % SKILL_SIZE_;

        if (cur_pos_index_ - real_idx_pos_arr_[end_slot_index_] == -1)
        {
            var new_end_real_pos = (real_idx_pos_arr_[end_slot_index_] + 1) % SLOT_SIZE_;
            real_idx_pos_arr_[new_end_idx] = new_end_real_pos;
            end_slot_index_ = new_end_idx;
            front_slot_index_ = (front_slot_index_ + 1) % SKILL_SIZE_;
        }
        else if (cur_pos_index_ == (SLOT_SIZE_ - 1) && real_idx_pos_arr_[end_slot_index_] == 0)
        {
            real_idx_pos_arr_[new_end_idx] = 1;
            end_slot_index_ = new_end_idx;
            front_slot_index_ = (front_slot_index_ + 1) % SKILL_SIZE_;
        }

        cur_pos_index_ = (cur_pos_index_ + 1) % SLOT_SIZE_;
        cur_skill_index_ = (cur_skill_index_ + 1) % SKILL_SIZE_;

        target_rotation_ = Quaternion.Euler(new Vector3(0, 0, target_rotation_.eulerAngles.z + 45));
    }

    public void rotateCurrntSkill(int _target_skill_num)
    {
        int cur_skill_num = SkillManager.instance.curr_skill_index;
        int value = _target_skill_num - cur_skill_num;

        if (value > 2)
        {
            value -= 5;
        }
        else if (value < -2)
        {
            value += 5;
        }

        rotateSkillCircleByStep(value);
        SkillManager.instance.moveCurrSkillCursor(_target_skill_num);
    }

    public void rotateSkillCircleByStep(int _step)
    {
        if (_step > 0)
        {
            for (int i = 0; i < _step; i++)
            {
                rotatePrivious();
            }
        }
        else if (_step < 0)
        {
            for (int i = 0; i < _step * -1; i++)
            {
                rotateNext();
            }
        }
    }
}
