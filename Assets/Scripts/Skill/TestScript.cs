using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private int curr_book_index_ = 3;
    private int curr_skill_index_ = 1;

    [SerializeField]
    private Transform skill_positions_parent_;
    [SerializeField]
    private Transform skill_book_panels_tr_parent_;

    private Transform[] skill_position_arr_;
    private Transform[] skill_book_panel_tr_arr_;

    private const int REAL_BOOK_SIZE = 6;
    private const int SKILL_BOOK_SIZE = 3;

    [SerializeField]
    private float ui_speed_ = 3f;

    private int[] real_idx_book_data_arr_ = { 0, 1, 2, 0, 1, 2 };
    private int[] real_idx_pos_arr_ = { 0, 1, 2, 3, 4 };

    private void init()
    {
        skill_position_arr_ = Utility.getChildsTransform(skill_positions_parent_);
        skill_book_panel_tr_arr_ = Utility.getChildsTransform(skill_book_panels_tr_parent_);
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

        }
    }

    private void updateSkillBookPosition(int _idx)
    {
        Transform curr_book_tr_ = skill_book_panel_tr_arr_[_idx];
        curr_book_tr_.position = Vector3.Lerp(curr_book_tr_.position, skill_position_arr_[real_idx_pos_arr_[_idx]].position, Time.deltaTime * ui_speed_);
    }

    private void updateSkillBookScale(int _idx)
    {
        Transform curr_book_tr_ = skill_book_panel_tr_arr_[_idx];
        if (curr_book_index_ == _idx)
        {
            curr_book_tr_.localScale = Vector3.Lerp(curr_book_tr_.localScale, Vector3.one * 1.25f, Time.deltaTime * ui_speed_);
        }
        else
        {
            curr_book_tr_.localScale = Vector3.Lerp(curr_book_tr_.localScale, Vector3.one, Time.deltaTime * ui_speed_);
        }
    }

    private void moveLeft()
    {
        curr_book_index_ = Utility.modNumber(curr_book_index_, REAL_BOOK_SIZE, -1);
        

    }

    private void moveRight()
    {

    }    
}

