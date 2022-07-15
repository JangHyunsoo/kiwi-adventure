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
    NOMAL,
    RARE
}

public enum SkillRarity
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

    public static Vector2Int dirToVector(Direction _dir)
    {
        return direction_pos[_dir];
    }

    public static Transform[] getChildsTransform(Transform parent_)
    {
        Transform[] ret = new Transform[parent_.childCount];
        for (int i = 0; i < parent_.childCount; i++)
        {
            ret[i] = parent_.GetChild(i);
        }
        return ret;
    }

    public static Vector3 getScreenMousePos()
    {
        Vector3 mouse_pos_ = Input.mousePosition;
        Vector3 trans_pos_ = Camera.main.ScreenToWorldPoint(mouse_pos_);
        Vector3 target_pos_ = new Vector3(trans_pos_.x, trans_pos_.y, 0);

        return target_pos_;
    }


    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}

