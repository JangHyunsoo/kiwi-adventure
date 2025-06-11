using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public KeyActionType key_action_type;
    public KeyCode key;

    public Command(KeyActionType _type, KeyCode _key)
    {
        key_action_type = _type;
        key = _key;
        init();
    }

    public void act()
    {
        if(isPressed())
        {
            activate();
        }
    }

    public virtual void init(){}

    public virtual void activate() { }

    public bool isPressed()
    {
        switch (key_action_type)
        {
            case KeyActionType.DOWN:
                return Input.GetKeyDown(key);
            case KeyActionType.UP:
                return Input.GetKeyUp(key);
            case KeyActionType.DURING:
                return Input.GetKey(key);
            default:
                return false;
        }
    }
}
