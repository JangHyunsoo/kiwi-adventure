using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterActionCommand : Command
{
    private PlayerInteraction player_interaction_;

    public InterActionCommand(KeyActionType _type, KeyCode _key) : base(_type, _key) {  }

    public override void activate()
    {
        if (player_interaction_ == null)
        {
            Debug.Log("PlayerInteraction");
            player_interaction_ = obj_.GetComponent<PlayerInteraction>();
        }

        if(player_interaction_.detectObject())
        {
            player_interaction_.detected_object.GetComponent<InteractionEvent>().activate();
        }
    }
}
