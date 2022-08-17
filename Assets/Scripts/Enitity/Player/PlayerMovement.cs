using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement
{
    private bool is_freeze_ = true;
    private bool is_empty_ = true;

    private Queue<Vector3> reserved_position_queue_ = new Queue<Vector3>();

    [SerializeField]
    private Transform skill_fire_rot_;

    public override void init()
    {
        base.init();
        StartCoroutine(delay(1f));
    }

    private void Update()
    {
        moveCommand();

        is_empty_ = reserved_position_queue_.Count == 0;

        PlayerManager.instance.player_animator.SetBool("isRun", is_move_);
    }


    public override void move()
    {
        if (is_freeze_) return;

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

    private void moveCommand()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetMouseButtonDown(1))
            {
                target_pos_ = Utility.getScreenMousePos();
                reserved_position_queue_.Enqueue(target_pos_);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            reserved_position_queue_.Clear();
            target_pos_ = Utility.getScreenMousePos();
        }
        else if (Input.GetMouseButtonDown(2))
        {
            stopMove();
        }
    }

    public override void stopMove()
    {
        reserved_position_queue_.Clear();
        target_pos_ = transform.position;
    }

    private IEnumerator delay(float _delay_time)
    {
        yield return new WaitForSeconds(_delay_time);
        is_freeze_ = false;
    }
}
