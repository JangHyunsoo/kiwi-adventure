using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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

public enum ProjectileType
{
    MOVE_CIRCLE = 0,
    MOVE_BOX
}

public enum Rarity
{
    COMMON,
    UNCOMMON,
    RARE,
    LEGENDARY
}

public enum ElementalType
{
    FIRE,
    ICE,
    WATER,
    ELECTRIC,
    EARTH,
    DARK
}

public enum SkillBookOption
{
    FIRE_DAMAGE,
    ICE_DAMAGE,
    WATER_DAMAGE,
    ELETRIC_DAMAGE,
    EARTH_DAMAGE,
    DARK_DAMAMGE,
    COOL_TIME,
    CRITICAL_CHANCE,
    CRITICAL_DAMAGE
}

public enum KeyActionType
{
    DOWN,
    UP,
    DURING
}

public enum KeyCommand
{
    ONE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX
}

public struct ElementalData
{
    public ElementalType elemental_type;
    public float elemental_value;
    public ElementalData(ElementalType _elemental_type, float _elemental_value)
    {
        elemental_type = _elemental_type;
        elemental_value = _elemental_value;
    }
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

    public static Direction reverseDirection(Direction _dir)
    {
        if (_dir == Direction.BOTTOM) return Direction.TOP;
        else if (_dir == Direction.TOP) return Direction.BOTTOM;
        else if (_dir == Direction.LEFT) return Direction.RIGHT;
        else return Direction.LEFT;
    }

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

    public static int randIndex(params float[] percent)
    {
        float[] stack_percent = new float[percent.Length];
        stack_percent[0] = percent[0];
        for (int i = 1; i < stack_percent.Length; i++)
        {
            stack_percent[i] = stack_percent[i - 1] + percent[i];
        }
        float rand = Random.RandomRange(0f, 1f);
        
        for(int i = 0; i < stack_percent.Length; i++)
        {
            if (stack_percent[i] >= rand)
                return i;
        }
        return -1;
    }

    public static int modNumber(int _num, int _max, int _cal)
    {
        int result = (_num + _cal) % _max;
        return result < 0 ? result + _max : result;
    }

    public static Quaternion getDirecitonToRotation(Vector3 _vec)
    {
        return Quaternion.Euler(new Vector3(0f, 0f, getDegreeFromRadian(Mathf.Atan2(_vec.y, _vec.x))));
    }
    
    public static float getDegreeFromRadian(float _radian)
    {
        return _radian * 180 / Mathf.PI;
    }

    public static int[] getShuffleArray(int _size)
    {
        int[] shuffle_arr = Enumerable.Range(0, _size).ToArray();
        System.Random random = new System.Random();
        shuffle_arr = shuffle_arr.OrderBy(x => random.Next()).ToArray();
        return shuffle_arr;
    }

    public static T getRandomValueInArray<T>(T[] _array)
    {
        return _array[Random.Range(0, _array.Length)];
    }
}

