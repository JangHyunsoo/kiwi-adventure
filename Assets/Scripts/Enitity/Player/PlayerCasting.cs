using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    private readonly KeyCode[] skill_key = 
    { 
        KeyCode.Q, KeyCode.W, KeyCode.E, 
        KeyCode.R, KeyCode.A, KeyCode.S, 
        KeyCode.D, KeyCode.F 
    };

    private readonly KeyCode[] skill_idx_ =
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6,
        KeyCode.Alpha7, KeyCode.Alpha8
    };

    private Vector3 mouse_pos_;
    private Vector3 trans_pos_;
    private Vector3 target_pos_;

    [SerializeField]
    private int command_idx_ = 0;
    [SerializeField]
    private bool is_casting_ = false;
    [SerializeField]
    private bool is_reload_ = false;

    private int[] cur_command_list_; 


    private void Update()
    {
        if (is_reload_)
        {
            fireSkill();
        }

        if (!is_casting_)
        {
            moveCurrSkillCursorWithKeyboard();
        }
    }
    private void moveCurrSkillCursorWithKeyboard()
    {
        if (Input.anyKeyDown)
        {
            for(int i = 0; i < skill_idx_.Length; i++)
            {
                if (Input.GetKeyDown(skill_idx_[i]))
                {
                    changeSkill(i);
                    is_reload_ = false;
                    command_idx_ = 0;
                    is_casting_ = false;
                }
            }
        }
    }

    private void changeSkill(int _idx)
    {
        SkillInventory.instance.moveCurrSkillCursor(_idx);
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
        cur_command_list_ = SkillInventory.instance.getCurrSkill().skill_data.command;
    }


    public bool compareSkillCommand(int _command_code)
    {
        return cur_command_list_[command_idx_] == _command_code;
    }
    public int getCurrentSkillCommand(int _index)
    {
        return cur_command_list_[_index];
    }
    
    public void nextCommand()
    {
        command_idx_++;
    }

    public bool isFinishCasting()
    {
        return cur_command_list_.Length == command_idx_;
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