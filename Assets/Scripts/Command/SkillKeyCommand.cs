using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillKeyCommand : Command
{
    private int command_code_;

    public SkillKeyCommand(KeyActionType _type, KeyCode _key, int _command_code) : base(_type, _key)
    {
        command_code_ = _command_code;
    }

    public override void activate()
    {
        var player_casting = PlayerManager.instance.player_casting;

        if (player_casting.isCasting())
        {
            if (player_casting.compareSkillCommand(command_code_))
            {
                player_casting.nextCommand();

                if (player_casting.isFinishCasting())
                {
                    player_casting.readySkill();
                }
            }
            else
            {
                player_casting.failSkill();
            }
        }
    }
}
