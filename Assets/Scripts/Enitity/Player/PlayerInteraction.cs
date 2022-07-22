using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private Transform detection_point_;
    [SerializeField]
    private float detection_distance_ = 0.2f;
    public LayerMask detection_layer;
    public GameObject detected_object;

    public void init()
    {
        detection_point_ = PlayerManager.instance.player.transform;
    }

    public bool detectObject()
    {
        var detected = Physics2D.OverlapCircle(detection_point_.position, detection_distance_, detection_layer);

        if (detected != null)
        {
            detected_object = detected.gameObject;
            return true;
        }
        else return false;
    }
}