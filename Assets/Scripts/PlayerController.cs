using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb_;
    private Vector3 target_pos_;
    private bool is_freeze = true;
    private bool is_empty = true;
    private Queue<Vector3> reserved_position_list_ = new Queue<Vector3>();

    private void Update()
    {
        if (is_freeze) return;

        moveCommand();

        is_empty = reserved_position_list_.Count == 0;

        if (is_empty)
        {
            moveToTarget(target_pos_, PlayerManager.instance.player.cur_speed);
        }
        else if (!is_empty)
        {
            if (Vector2.Distance(reserved_position_list_.Peek(), transform.position) <= 0.1f)
            {
                reserved_position_list_.Dequeue();
            }
            else
            {
                moveToTarget(reserved_position_list_.Peek(), PlayerManager.instance.player.cur_speed);
            }
        }
    }

    private void Awake()
    {
        rb_ = GetComponent<Rigidbody2D>();
        target_pos_ = transform.position;
        StartCoroutine(delay(1f));
    }


    public void moveCommand()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetMouseButtonDown(1))
            {
                calTargetPos();
                reserved_position_list_.Enqueue(target_pos_);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            reserved_position_list_.Clear();
            calTargetPos();
        }
        else if(Input.GetMouseButtonDown(2))
        {
            stopMove();
        }
    }

    private void calTargetPos()
    {
        Vector3 mouse_pos_ = Input.mousePosition;
        Vector3 trans_pos_ = Camera.main.ScreenToWorldPoint(mouse_pos_);
        target_pos_ = new Vector3(trans_pos_.x, trans_pos_.y, 0);
    }

    private void moveToTarget(Vector3 _target_pos, float _speed)
    {
        Vector2 dir = (_target_pos - transform.position).normalized * Time.deltaTime * _speed;
        rb_.MovePosition(rb_.position + dir);

        if (Vector2.Distance(target_pos_, transform.position) <= 0.1f) rb_.MovePosition(target_pos_);

        //transform.position = Vector3.MoveTowards(transform.position, target_pos_, Time.deltaTime * _speed);
    }

    private void stopMove()
    {
        reserved_position_list_.Clear();
        target_pos_ = transform.position;
    }

    private IEnumerator delay(float _delay_time)
    {
        yield return new WaitForSeconds(_delay_time);
        is_freeze = false;
    }
}
