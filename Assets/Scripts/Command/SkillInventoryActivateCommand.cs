using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventoryActivateCommand : Command
{
    private bool is_activate_ = false;

    public SkillInventoryActivateCommand(KeyActionType _type, KeyCode _key) : base(_type, _key){ }

    public override void activate()
    {
        if (is_activate_ == false)
        {
            is_activate_ = true;
            SkillManager.instance.setSkillInventoryActivate(is_activate_);
        }
        else
        {
            is_activate_ = false;
            SkillManager.instance.setSkillInventoryActivate(is_activate_);
        }
    }
}
