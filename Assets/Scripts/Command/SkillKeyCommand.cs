using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillKeyCommand : Command
{
    private PlayerCasting player_casting_;
    private int command_code_;

    public SkillKeyCommand(KeyActionType _type, KeyCode _key, int _command_code) : base(_type, _key)
    {
        command_code_ = _command_code;
    }

    public override void activate()
    {
        if(player_casting_ == null)
        {
            player_casting_ = obj_.GetComponent<PlayerCasting>();
        }

        if (player_casting_.isCasting())
        {
            if (player_casting_.compareSkillCommand(command_code_))
            {
                player_casting_.nextCommand();

                if (player_casting_.isFinishCasting())
                {
                    player_casting_.readySkill();
                }
            }
            else
            {
                player_casting_.failSkill();
            }
        }
    }
}
