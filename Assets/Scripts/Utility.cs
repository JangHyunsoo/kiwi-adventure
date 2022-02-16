using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    LEFT, RIGHT, TOP, BOTTOM
};
public enum RoomDirection
{
    LEFT, MIDDLE, RIGHT
}
public enum EnemyType
{
    MONSTER,
    BOSS
};
public enum Team
{
    PLAYER,
    ENEMY,
    NPC
}
public enum ItemType
{
    COUNTABLE,
    UNCOUNTABLE
}

public enum SkillBookRarity
{
    COMMON,
    UNCOMMON,
    RARE,
    LEGENDARY
}

public class Utility
{
    public static string ProjectileTag = "Projectile";
    public static string PlayerTag = "Player";
    public static string MonsterTag = "Monster";

    public static Dictionary<Direction, Vector2Int> direction_pos = new Dictionary<Direction, Vector2Int>()
    {
        { Direction.LEFT,   new Vector2Int(-1, 0) },
        { Direction.RIGHT,  new Vector2Int(1, 0) },
        { Direction.TOP,    new Vector2Int(0, 1) },
        { Direction.BOTTOM, new Vector2Int(0, -1) }
    };

    public static Transform[] getChildsTransform(Transform parent_)
    {
        Transform[] ret = new Transform[parent_.childCount];
        for (int i = 0; i < parent_.childCount; i++)
        {
            ret[i] = parent_.GetChild(i);
        }
        return ret;
    }

}

