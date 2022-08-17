using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    protected Rigidbody2D rb_;
    protected Vector3 target_pos_;
    protected bool is_move_ { get => target_pos_ != transform.position; }
    public bool is_move { get => is_move_; }
    protected bool is_casting_ = false;
    public bool is_casting { get => is_casting_; }
    

    public virtual void init()
    {
        rb_ = GetComponent<Rigidbody2D>();
        target_pos_ = transform.position;
    }

    private void FixedUpdate()
    {
        if (!is_casting_)
        {
            move();
        }
    }

    public virtual void move() { }

    protected void moveToTarget(Vector3 _target_pos, float _speed)
    {
        if (Vector2.Distance(_target_pos, transform.position) <= Time.deltaTime * _speed)
        {
            rb_.MovePosition(_target_pos);
        }
        else
        {
            Vector2 dir = (_target_pos - transform.position).normalized * Time.deltaTime * _speed;
            rb_.MovePosition(rb_.position + dir);
            //    PlayerManager.instance.player_go.GetComponent<SpriteRenderer>().flipX = dir.x > 0;
            //    skill_fire_rot_.rotation = Quaternion.Euler(new Vector3(0f, dir.x > 0 ? 180f : 0f, 0f));
        }
    }

    public void setCastingState(bool _value)
    {
        is_casting_ = _value;
    }

    public void reset()
    {
        target_pos_ = transform.position;
    }

    public virtual void stopMove()
    {
        target_pos_ = transform.position;
    }

}
