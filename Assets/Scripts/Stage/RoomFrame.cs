using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFrame : MonoBehaviour
{
    [SerializeField]
    private GameObject[] left_door_tile_;
    [SerializeField]
    private GameObject[] right_door_tile_;
    [SerializeField]
    private GameObject[] top_door_tile_;
    [SerializeField]
    private GameObject[] bottom_door_tile_;

    [SerializeField]
    private GameObject left_door_;
    [SerializeField]
    private GameObject right_door_;
    [SerializeField]
    private GameObject top_door_;
    [SerializeField]
    private GameObject bottom_door_;

    private Vector2Int room_pos;
    private HashSet<Direction> _open_direction = new HashSet<Direction>();

    private SpawnObject[] spawn_object_list_;

    public void createTile()
    {
        spawn_object_list_ = GetComponentsInChildren<SpawnObject>();
        foreach (var obj in spawn_object_list_)
        {
            obj.spawnTile();
        }
    }

    public void openDoor(Direction _direction)
    {
        _open_direction.Add(_direction);

        switch (_direction)
        {
            case Direction.LEFT:
                foreach (var door in left_door_tile_)
                {
                    door.SetActive(false);
                }
                left_door_.SetActive(true);
                left_door_.GetComponent<Door>().closeDoor();
                break;
            case Direction.RIGHT:
                foreach (var door in right_door_tile_)
                {
                    door.SetActive(false);
                }
                right_door_.SetActive(true);
                right_door_.GetComponent<Door>().closeDoor();
                break;
            case Direction.TOP:
                foreach (var door in bottom_door_tile_)
                {
                    door.SetActive(false);
                }
                bottom_door_.SetActive(true);
                bottom_door_.GetComponent<Door>().closeDoor();
                break;
            case Direction.BOTTOM:
                foreach (var door in top_door_tile_)
                {
                    door.SetActive(false);
                }
                top_door_.SetActive(true);
                top_door_.GetComponent<Door>().closeDoor();
                break;
        }
    }

    public void clear()
    {
        foreach (var dir in _open_direction)
        {
            switch (dir)
            {
                case Direction.LEFT:
                    left_door_.GetComponent<Door>().openDoor();
                    break;
                case Direction.RIGHT:
                    right_door_.GetComponent<Door>().openDoor();
                    break;
                case Direction.TOP:
                    bottom_door_.GetComponent<Door>().openDoor();
                    break;
                case Direction.BOTTOM:
                    top_door_.GetComponent<Door>().openDoor();
                    break;
            }
        }
    }
}