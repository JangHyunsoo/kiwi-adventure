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
    protected float projectile_damage_;
    protected int skill_level_ = 0;

    protected bool is_ready = true;
    protected bool is_end = false; 


    public string team { get { return team_; } }

    public void Start()
    {
        skill_data_ = SkillDataBase.instance.getSkillData(skill_no_);
        init();
    }
    private void Update()
    {
        activate();
    }
    public virtual void init() { }
    public virtual void activate() { }
    
    public void setLevel(int _level)
    {
        skill_level_ = _level;
    }

    public void setTeam(string _team)
    {
        team_ = _team;
    }
    public void setPosition(Vector3 _my_pos, Vector3 _target_pos)
    {
        my_pos_ = _my_pos;
        target_pos_ = _target_pos;
    }

    public void endReady()
    {
        is_ready = false;
    }
}
