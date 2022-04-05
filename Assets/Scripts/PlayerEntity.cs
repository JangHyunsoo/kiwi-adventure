using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    protected override void onDie()
    {
        Debug.Log("GameOver");
    }
}
