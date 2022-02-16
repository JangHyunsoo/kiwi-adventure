using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected string team_;
    protected int damage_;
    protected Vector3 my_pos_;
    protected Vector3 target_pos_;

    public string team { get { return team_; } }

    private void Start()
    {
        init();
    }
    private void Update()
    {
        activate();
    }
    public virtual void init() {}
    public virtual void activate() { }
    public void setTeam(string _team)
    {
        team_ = _team;
    }
    public void setPosition(Vector3 _my_pos, Vector3 _target_pos)
    {
        my_pos_ = _my_pos;
        target_pos_ = _target_pos;
    }
}
