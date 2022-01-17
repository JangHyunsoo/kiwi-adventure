using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform target_;

    void Start()
    {
        // fucking player
        target_ = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = target_.position;
        pos.z = -10;
        transform.position = pos;
    }
}
