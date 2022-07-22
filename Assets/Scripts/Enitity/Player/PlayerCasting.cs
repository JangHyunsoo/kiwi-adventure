using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    private int command_idx_ = 0;
    private bool is_casting_ = false;
    private bool is_reload_ = false;

    private int[] cur_command_arr_; 

    private void Update()
    {
        if (is_reload_)
        {
            fireSkill();
        }
    }
 
    private void fireSkill()    // Å¬¸¯
    {
        if (Input.GetMouseButtonDown(0))
        {
            SkillInventory.instance.getCurrSkill().activate(transform.position, Utility.getScreenMousePos(), tag);
            is_reload_ = false;
            is_casting_ = false;
            SkillInventory.instance.setCommand(false);
        }
    }

    public bool isCasting()
    {
        return is_casting_;
    }
    
    public void setIsCasting(bool _value)
    {
        is_casting_ = _value;
    }

    public void loadSkillCommand()
    {
        cur_command_arr_ = SkillInventory.instance.getCurrSkill().skill_data.command;
    }

    public bool compareSkillCommand(int _command_code)
    {
        return cur_command_arr_[command_idx_] == _command_code;
    }

    public int getCurrentSkillCommand(int _index)
    {
        return cur_command_arr_[_index];
    }
    
    public void nextCommand()
    {
        command_idx_++;
    }

    public bool isFinishCasting()
    {
        return cur_command_arr_.Length == command_idx_;
    }

    public void failSkill()
    {
        command_idx_ = 0;
        is_casting_ = false;
    }

    public void readySkill()
    {
        is_reload_ = true;
        command_idx_ = 0;
        is_casting_ = false;
    }
}