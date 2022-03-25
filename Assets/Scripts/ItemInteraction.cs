using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private Transform detection_point;
    private const float detection_radius = 0.2f;
    public LayerMask detection_layer;

    public GameObject detected_object;

    private void Start()
    {
        detection_point = PlayerManager.instance.player.transform;
    }


    void Update()
    {
        if (inputKey())
        {
            if (detectObject())
            {
                detected_object.GetComponent<Item>().item_data.activate();
                ItemInventory.instance.addItem(detected_object.GetComponent<Item>().item_data);
                GameObject.Destroy(detected_object);
            }
        }
    }

    bool inputKey()
    {
        return Input.GetKeyDown(KeyCode.CapsLock);
    }
    


    bool detectObject()
    {
        detected_object = Physics2D.OverlapCircle(detection_point.position, detection_radius, detection_layer).gameObject;

        if (detected_object == null) return false;
        else return true;
    }
    
}