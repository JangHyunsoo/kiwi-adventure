using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Transform[] left_door;
    private Transform[] right_door;
    private Transform[] top_door;
    private Transform[] bottom_door;

    private Vector2Int room_pos;
    private HashSet<Direction> _open_direction;

    public void openDoor(Direction _direction)
    {
        if(_direction == Direction.LEFT)
        {
            left_door[0].gameObject.active = false;
            left_door[1].gameObject.active = false;
        }
        else if (_direction == Direction.RIGHT)
        {
            right_door[0].gameObject.active = false;
            right_door[1].gameObject.active = false;
        }
        else if (_direction == Direction.TOP)
        {
            top_door[0].gameObject.active = false;
            top_door[1].gameObject.active = false;
        }
        else if(_direction == Direction.BOTTOM)
        {
            bottom_door[0].gameObject.active = false;
            bottom_door[1].gameObject.active = false;
        }
    }
}