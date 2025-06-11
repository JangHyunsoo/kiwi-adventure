using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private GameObject room_frame_prefab_;
    [SerializeField]
    private GameObject room_flied_prefab_;

    private RoomFrame room_frame_;
    private RoomFlied room_flied_;

    public void createRoom()
    {
        GameObject room_frame_go = Instantiate(room_frame_prefab_, transform.position, Quaternion.identity);
        GameObject room_flied_go = Instantiate(room_flied_prefab_, transform.position, Quaternion.identity);
        room_frame_go.transform.SetParent(transform);
        room_flied_go.transform.SetParent(transform);
        room_frame_ = room_frame_go.GetComponent<RoomFrame>();
        room_flied_ = room_flied_go.GetComponent<RoomFlied>();
        room_frame_.createTile();
    }

    public void openDoor(Direction dir)
    {
        room_frame_.openDoor(dir);
    }

    public void clear()
    {
        room_frame_.clear();
    }

    public void startRoom()
    {
        room_flied_.startRoom();
    }
}
