using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSwitchCommand : Command
{
    private int key_code_;

    public SkillSwitchCommand(KeyActionType _type, KeyCode _key, int _key_code) : base(_type, _key)
    {
        key_code_ = _key_code;
    }

    public override void activate()
    {
        PlayerManager.instance.player_casting.failSkill();
        SkillManager.instance.castingSkillAction(key_code_);
    }
}
