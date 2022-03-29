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

    private Vector3 mouse_pos_;
    private Vector3 trans_pos_;
    private Vector3 target_pos_;

    [SerializeField]
    private int _command_idx = 0;
    [SerializeField]
    private bool _isCasting = false;
    [SerializeField]
    private bool _isReload = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (!_isCasting)
        {
            startCastSkill();
        }
        else
        {
            castSkill();
        }
        if (_isReload)
        {
            fireSkill();
        }
    }
    private void startCastSkill()    // 스페이스바
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isCasting = true;
        }
    }
    private void castSkill()
    {
        if (Input.anyKeyDown)
        {
            for(int i = 0; i < skill_key.Length; i++)
            {
                KeyCode curr_key = skill_key[i];
                if (Input.GetKeyDown(skill_key[i]))
                {
                    if (SkillInventory.instance.getCurrSkill().skill_data.command[_command_idx] != curr_key.ToString()[0])
                    {
                        FailCommand();
                    }
                    else
                    {
                        _command_idx++;
                        if(_command_idx == SkillInventory.instance.getCurrSkill().skill_data.command.Length)
                        {
                            _isReload = true;
                            _command_idx = 0;
                            _isCasting = false;
                        }
                    }
                }
            }
        }
    }
    private void FailCommand()
    {
        _command_idx = 0;
        _isCasting = false;
    }

    private void fireSkill()    // 클릭
    {
        if (Input.GetMouseButtonDown(0))
        {
            SkillDataBase.instance.getSkill(0).activate(transform.position, Utility.getScreenMousePos());
            _isReload = false;
        }
    }
}