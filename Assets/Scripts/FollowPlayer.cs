using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform target_;
    private Vector3 target_pos_;
    private Vector3 follow_pos_;
    
    void Start()
    {
    }

    void Update()
    {
        setTarget();
        followTargetPos();
        transform.position = follow_pos_;
    }

    void setTarget()
    {
        // player_target == null 생각하기
        target_ = PlayerManager.instance.player.transform;
        target_pos_ = target_.position;
        target_pos_.z = -10;
    }

    void followTargetPos()
    {
        follow_pos_ = Vector3.Lerp(transform.position, target_pos_, Time.deltaTime * 5f);
    }


}
