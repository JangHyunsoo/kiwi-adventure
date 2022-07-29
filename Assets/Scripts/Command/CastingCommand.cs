using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingCommand : Command
{
    public CastingCommand(KeyActionType _type, KeyCode _key) : base(_type, _key) { }

    public override void activate()
    {
        var player_casting = PlayerManager.instance.player_casting;


        if (SkillManager.instance.getCurrSkill() == null) return;
        if (!SkillManager.instance.getCurrSkill().is_ready) return;

        if (!player_casting.isCasting())
        {
            player_casting.setIsCasting(true);
        }
        else
        {
            player_casting.setIsCasting(false);
        }
    }


}
