using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterActionCommand : Command
{
    public InterActionCommand(KeyActionType _type, KeyCode _key) : base(_type, _key) {  }

    public override void activate()
    {
        if(PlayerManager.instance.player_interaction.detectObject())
        {
            PlayerManager.instance.player_interaction.detected_object.GetComponent<InteractionEvent>().activate();
        }
    }
}
