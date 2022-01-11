using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb_;
    private Vector3 mouse_pos_;
    private Vector3 trans_pos_;
    private Vector3 target_pos_;
    
    private void Update()
    {
    }

    private void Awake()
    {
        rb_ = GetComponent<Rigidbody2D>();
    }
    public void movePlayer(float _speed)
    {
        if(Input.GetMouseButtonDown(1)) { calTargetPos(); }
        moveToTarget(_speed);
    }

    private void calTargetPos()
    {
        mouse_pos_ = Input.mousePosition;
        trans_pos_ = Camera.main.ScreenToWorldPoint(mouse_pos_);
        target_pos_ = new Vector3(trans_pos_.x, trans_pos_.y, 0);
    }
    private void moveToTarget(float _speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, target_pos_, Time.deltaTime * _speed);
    }
}
