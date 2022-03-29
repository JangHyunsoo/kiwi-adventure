using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb_;
    private Vector3 mouse_pos_;
    private Vector3 trans_pos_;
    private Vector3 target_pos_;
    private bool isFreeze = true;

    private void Update()
    {
        if (isFreeze) return;
        movePlayer(PlayerManager.instance.player.player_data.speed);
    }

    private void Awake()
    {
        rb_ = GetComponent<Rigidbody2D>();
        target_pos_ = transform.position;
        StartCoroutine(delay(1f));
    }
    public void movePlayer(float _speed)
    {
        if(Input.GetMouseButtonDown(1)) { calTargetPos(); }
        if(Input.GetKeyDown(KeyCode.LeftShift)) { stopMove(); }
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
        //Vector2 dir = (target_pos_ - transform.position).normalized * Time.deltaTime * _speed;
        //rb_.MovePosition(rb_.position + dir);

        //if (Vector2.Distance(target_pos_, transform.position) <= 0.1f) rb_.MovePosition(target_pos_);

        transform.position = Vector3.MoveTowards(transform.position, target_pos_, Time.deltaTime * _speed);
    }

    private void stopMove()
    {
        target_pos_ = transform.position;
    }

    private IEnumerator delay(float _delay_time)
    {
        yield return new WaitForSeconds(_delay_time);
        isFreeze = false;
    }
}
