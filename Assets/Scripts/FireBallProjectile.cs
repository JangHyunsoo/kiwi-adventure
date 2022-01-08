using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : Projectile
{
    private Vector3 _mouse_pos;
    private Vector3 _trans_pos;
    private Vector3 _target_pos;
    private Vector2 _direction;
    

    public override void init()
    {
        _delay_time = 5d;
        _mouse_pos = Input.mousePosition;
        _trans_pos = Camera.main.ScreenToWorldPoint(_mouse_pos);
        _target_pos = new Vector3(_trans_pos.x, _trans_pos.y, 0);

        _direction = (_target_pos - transform.position).normalized;
    }
    public override void activate()
    {
        transform.Translate(_direction * Time.deltaTime * 10f);
        _current_delay_time += Time.deltaTime;

        if(_delay_time < _current_delay_time)
        {
            Destroy(this.gameObject);
        }
    }
}
