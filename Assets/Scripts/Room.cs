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
    private HashSet<Direction> _open_direction;

    public void openDoor(Direction _direction)
    {
        if(_direction == Direction.LEFT)
        {
            left_door[0].SetActive(false);
            left_door[1].SetActive(false);
        }
        else if (_direction == Direction.RIGHT)
        {
            right_door[0].SetActive(false);
            right_door[1].SetActive(false);
        }
        else if (_direction == Direction.TOP)
        {
            bottom_door[0].SetActive(false);
            bottom_door[1].SetActive(false);
        }
        else if(_direction == Direction.BOTTOM)
        {
            top_door[0].SetActive(false);
            top_door[1].SetActive(false);
        }
    }
}