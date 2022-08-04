using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected int skill_no_;
    public int skill_no { get => skill_no_; }
    protected SkillData skill_data_;
    protected string team_;
    protected Vector3 my_pos_;
    protected Vector3 target_pos_;

    public string team { get { return team_; } }

    public virtual void Start()
    {
        skill_data_ = SkillDataBase.instance.getSkillData(skill_no_);
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
