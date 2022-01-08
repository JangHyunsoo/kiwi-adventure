using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int _damage;
    public double _delay_time;
    public double _current_delay_time;

    private void Start()
    {
        _current_delay_time = 0d;
        init();
    }
    private void Update()
    {
        activate();
    }
    public virtual void init() {}
    public virtual void activate() {}

}
