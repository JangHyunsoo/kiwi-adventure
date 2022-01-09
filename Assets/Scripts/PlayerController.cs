using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _mouse_pos;
    private Vector3 _trans_pos;
    private Vector3 _target_pos;
    
    private void Update()
    {
    }
    public void movePlayer()
    {
        if(Input.GetMouseButtonDown(1)) { calTargetPos(); }
        moveToTarget();
    }

    private void calTargetPos()
    {
        _mouse_pos = Input.mousePosition;
        _trans_pos = Camera.main.ScreenToWorldPoint(_mouse_pos);
        _target_pos = new Vector3(_trans_pos.x, _trans_pos.y, 0);
    }
    private void moveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target_pos, Time.deltaTime * 5f);
    }
}
