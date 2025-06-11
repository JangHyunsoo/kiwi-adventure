using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
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
        //var player_speed = PlayerManager.instance.player.cur_speed * 2f;
        //
        //if (Vector3.Distance(target_pos_, transform.position) < player_speed * Time.deltaTime)
        //{
        //    follow_pos_ = target_pos_;
        //}
        //else
        //{
        follow_pos_ = Vector3.Lerp(transform.position, target_pos_, Time.deltaTime * 1000f);
        //}
    }
}
