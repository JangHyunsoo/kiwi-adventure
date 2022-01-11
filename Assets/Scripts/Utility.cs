using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    LEFT, RIGHT, TOP, BOTTOM
};
public enum Enemytype
{
    MONSTER,
    BOSS
};

public class Utility
{
    public static Dictionary<Direction, Vector2Int> direction_pos = new Dictionary<Direction, Vector2Int>()
    {
        { Direction.LEFT,   new Vector2Int(-1, 0) },
        { Direction.RIGHT,  new Vector2Int(1, 0) },
        { Direction.TOP,    new Vector2Int(0, 1) },
        { Direction.BOTTOM, new Vector2Int(0, -1) }
    };

}

