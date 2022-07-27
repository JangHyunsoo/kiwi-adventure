using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb_;
    private Vector3 target_pos_;
    private bool is_freeze_ = true;
    private bool is_empty_ = true;
    [SerializeField]
    private bool is_move_;
    private Queue<Vector3> reserved_position_queue_ = new Queue<Vector3>();




    public void init()
    {
        rb_ = GetComponent<Rigidbody2D>();
        target_pos_ = transform.position;
        StartCoroutine(delay(1f));
    }

    private void Update()
    {

        is_move_ = target_pos_ != transform.position;
        if (is_freeze_) return;

        moveCommand();

        is_empty_ = reserved_position_queue_.Count == 0;

        PlayerManager.instance.player_animator.SetBool("isRun", is_move_);


        if (is_empty_)
        {
            moveToTarget(target_pos_, PlayerManager.instance.player.cur_speed);
        }
        else if (!is_empty_)
        {
            if (Vector2.Distance(reserved_position_queue_.Peek(), transform.position) <= 0.1f)
            {
                reserved_position_queue_.Dequeue();
            }
            else
            {
                moveToTarget(reserved_position_queue_.Peek(), PlayerManager.instance.player.cur_speed);
            }
        }


    }

    public void moveCommand()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetMouseButtonDown(1))
            {
                calTargetPos();
                reserved_position_queue_.Enqueue(target_pos_);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            reserved_position_queue_.Clear();
            calTargetPos();
        }
        else if (Input.GetMouseButtonDown(2))
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
        if (Vector2.Distance(target_pos_, transform.position) <= Time.deltaTime * _speed)
        {
            rb_.MovePosition(target_pos_);
        }
        else
        {
            Vector2 dir = (_target_pos - transform.position).normalized * Time.deltaTime * _speed;
            rb_.MovePosition(rb_.position + dir);
            PlayerManager.instance.player_go.GetComponent<SpriteRenderer>().flipX = dir.x > 0;
        }
    }

    private void stopMove()
    {
        reserved_position_queue_.Clear();
        target_pos_ = transform.position;
    }

    public void clear()
    {
        stopMove();
    }

    private IEnumerator delay(float _delay_time)
    {
        yield return new WaitForSeconds(_delay_time);
        is_freeze_ = false;
    }
}
