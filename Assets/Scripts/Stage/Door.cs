using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr_;
    [SerializeField]
    private Transform event_tr_;

    [SerializeField]
    private Direction direction_;

    [SerializeField]
    private Sprite open_sprite_;
    [SerializeField]
    private Sprite close_sprite_;

    private bool is_open_ = false;
    
    public void closeDoor()
    {
        is_open_ = false;
        sr_.sprite = close_sprite_;
        event_tr_.gameObject.active = false;
    }

    public void openDoor()
    {
        is_open_ = true;
        sr_.sprite = open_sprite_;
        event_tr_.gameObject.active = true;
        event_tr_.GetComponent<DoorEvent>().setDirection(direction_);
    }
}
