using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEquipmentScrollUI : MonoBehaviour
{
    private int curr_book_index_ = 3;

    [SerializeField]
    private Transform skill_positions_parent_;
    [SerializeField]
    private Transform skill_book_panels_tr_parent_;

    [SerializeField]
    private Transform[] skill_position_arr_;
    [SerializeField]
    private Transform[] skill_book_panel_tr_arr_;

    [SerializeField]
    private SkillEquipmentBookSlotUI[] skill_book_slot_cp_arr_;

    private const int REAL_BOOK_SIZE = 6;
    private const int SKILL_BOOK_SIZE = 3;

    [SerializeField]
    private float ui_speed_ = 0.5f;

    private int[] real_idx_book_data_arr_ = { 1, 2, 0, 1, 2, 0 };
    private int[] real_idx_pos_arr_ = { 0, 1, 2, 3, 4, 5 };

    public void init()
    {
        skill_position_arr_ = Utility.getChildsTransform(skill_positions_parent_);
        skill_book_panel_tr_arr_ = Utility.getChildsTransform(skill_book_panels_tr_parent_);
        skill_book_slot_cp_arr_ = skill_book_panels_tr_parent_.GetComponentsInChildren<SkillEquipmentBookSlotUI>();
        for (int i = 0; i < skill_book_slot_cp_arr_.Length; i++)
        {
            skill_book_slot_cp_arr_[i].init();
            skill_book_slot_cp_arr_[i].setBookNo(real_idx_book_data_arr_[i]);
        }
    }

    void Update()
    {
        updateSkillBook();
    }

    private void initSkillBookPosition()
    {
        for (int i = 0; i < REAL_BOOK_SIZE; i++)
        {
            Transform curr_book_tr_ = skill_book_panel_tr_arr_[i];
            curr_book_tr_.position = skill_position_arr_[real_idx_pos_arr_[i]].position;
        }
    }

    private void updateSkillBook()
    {
        for (int i = 0; i < REAL_BOOK_SIZE; i++)
        {
            updateSkillBookPosition(i);
            updateSkillBookScale(i);
            updateSkillBookImage(i);
        }
    }

    private void updateSkillBookPosition(int _idx)
    {
        int real_pos = real_idx_pos_arr_[_idx];
        Transform curr_book_tr_ = skill_book_panel_tr_arr_[real_pos];
        curr_book_tr_.position = Vector3.Lerp(curr_book_tr_.position, skill_position_arr_[_idx].position, Time.deltaTime * ui_speed_);
    }

    private void updateSkillBookScale(int _idx)
    {
        int real_pos = real_idx_pos_arr_[_idx];
        Transform curr_book_tr_ = skill_book_panel_tr_arr_[real_pos];
        if (curr_book_index_ == real_pos)
        {
            curr_book_tr_.localScale = Vector3.Lerp(curr_book_tr_.localScale, Vector3.one * 1.25f, Time.deltaTime * ui_speed_);
        }
        else
        {
            curr_book_tr_.localScale = Vector3.Lerp(curr_book_tr_.localScale, Vector3.one, Time.deltaTime * ui_speed_);
        }
    }

    private void updateSkillBookImage(int _idx)
    {
        skill_book_slot_cp_arr_[_idx].updateSkillSlots();
    }

    public void moveLeft()
    {
        curr_book_index_ = Utility.modNumber(curr_book_index_, REAL_BOOK_SIZE, 1);
        moveLeftArr();
    }
    
    public void moveLeftArr()
    {
        int real_pos_last_value = real_idx_pos_arr_[0];
        int real_book_last_value = real_idx_book_data_arr_[0];
        int real_pos_curr_value;
        int real_book_curr_value;

        skill_book_panel_tr_arr_[real_idx_pos_arr_[0]].position = skill_book_panel_tr_arr_[real_idx_pos_arr_[REAL_BOOK_SIZE - 1]].position;

        for (int i = REAL_BOOK_SIZE - 1; i >= 0; i--)
        {
            real_pos_curr_value = real_idx_pos_arr_[i];
            real_book_curr_value = real_idx_book_data_arr_[i];
            real_idx_pos_arr_[i] = real_pos_last_value;
            real_idx_book_data_arr_[i] = real_book_last_value;
            real_pos_last_value = real_pos_curr_value;
            real_book_last_value = real_book_curr_value;
        }
    }
}

