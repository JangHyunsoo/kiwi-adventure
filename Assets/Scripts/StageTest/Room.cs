using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private GameObject[] left_door;
    [SerializeField]
    private GameObject[] right_door;
    [SerializeField]
    private GameObject[] top_door;
    [SerializeField]
    private GameObject[] bottom_door;

    private Vector2Int room_pos;
    private HashSet<Direction> _open_direction = new HashSet<Direction>();

    public void openDoor(Direction _direction)
    {
        _open_direction.Add(_direction);

        if(_direction == Direction.LEFT)
        {
            foreach(var door in left_door)
            {
                door.SetActive(false);
            }
        }
        else if (_direction == Direction.RIGHT)
        {
            foreach (var door in right_door)
            {
                door.SetActive(false);
            }
        }
        else if (_direction == Direction.TOP)
        {
            foreach (var door in bottom_door)
            {
                door.SetActive(false);
            }
        }
        else if(_direction == Direction.BOTTOM)
        {
            foreach (var door in top_door)
            {
                door.SetActive(false);
            }
        }
    }
}