using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSkillBookCommand : Command
{
    public SwitchSkillBookCommand(KeyCode _key) : base(KeyActionType.DOWN, _key){}

    public override void activate()
    {
        PlayerManager.instance.player_casting.failSkill();
        SkillManager.instance.switchSkillBook();
    }
}