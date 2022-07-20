using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingCommand : Command
{
    private PlayerCasting player_casting_;
    
    public CastingCommand(KeyActionType _type, KeyCode _key) : base(_type, _key) { }
   
    public override void activate()
    {
        if (player_casting_ == null)
        {
            player_casting_ = obj_.GetComponent<PlayerCasting>();
        }
        
        if(!player_casting_.isCasting())
        {
            player_casting_.setIsCasting(true);
            player_casting_.loadSkillCommand();
            Debug.Log("스킬 실행 중");
        }
        else
        {
            player_casting_.setIsCasting(false);
        }
    }


}
