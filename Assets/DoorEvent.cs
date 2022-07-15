using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : InteractionEvent
{
    private Direction dir_;

    public override void activate()
    {
        Debug.Log("Door Event");
        StageManager.instance.moveRoom(dir_);
    }

    public void setDirection(Direction _dir)
    {
        dir_ = _dir;
    }
}
