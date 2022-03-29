using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform target_;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target_ = PlayerManager.instance.player.transform;

        if(target_ == null) return;

        Vector3 pos = target_.position;
        pos.z = -10;
        transform.position = pos;
    }
}
