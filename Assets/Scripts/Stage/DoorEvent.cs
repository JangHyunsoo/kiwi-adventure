using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : InteractionEvent
{
    private Direction dir_;

    public override void activate()
    {
        StageManager.instance.movePlayer(dir_);
    }

    public void setDirection(Direction _dir)
    {
        dir_ = _dir;
    }
}
