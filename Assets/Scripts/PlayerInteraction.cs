using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
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
                detected_object.GetComponent<InteractionEvent>().activate();
            }
        }
    }

    bool inputKey()
    {
        return Input.GetKeyDown(KeyCode.CapsLock);
    }
    


    bool detectObject()
    {

        var detected = Physics2D.OverlapCircle(detection_point.position, detection_radius, detection_layer);


        if (detected != null)
        {
            detected_object = detected.gameObject;
            return true;
        }
        else return false;
    }
    
}