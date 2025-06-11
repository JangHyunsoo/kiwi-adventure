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
    protected int skill_level_ = 0;

    protected bool is_ready_ = true;
    protected bool is_crash_ = false;
    protected bool is_end_ = false;

    public string team { get { return team_; } }

    public void Start()
    {
        skill_data_ = SkillDataBase.instance.getSkillData(skill_no_);
        init();
    }

    private void FixedUpdate()
    {
        activate();
    }

    public virtual void init() { }

    public virtual void activate()
    {
        if (!is_ready_ && !is_crash_)
        {
            GetComponent<Collider2D>().enabled = true;
            openingAction();
        }

        if (is_crash_)
        {
            destroyAction();
        }
    }

    public void setProjectile(int _level, Vector3 _my_pos, Vector3 _target_pos, string _team)
    {
        skill_level_ = _level;
        team_ = _team;
        my_pos_ = _my_pos;
        target_pos_ = _target_pos;
    }

    public virtual void openingAction() { }
    public virtual void destroyAction()
    {
        GetComponent<Animator>().SetBool("is_end", is_crash_);
    }
    public virtual void collisionEntity(Collider2D _collision) { }
    public virtual void collisionWall()
    {

        Destroy(gameObject);
    }
    

    public void OnTriggerStay2D(Collider2D _collision)
    {
        Debug.Log(_collision.name);
        if (_collision.tag != team_)
        {
            switch (_collision.tag)
            {
                case "Player":
                case "Monster":
                    collisionEntity(_collision);
                    break;
                case "Wall":
                    collisionWall();
                    break;
            }
        }
    }
    public void endReady()
    {
        is_ready_ = false;
    }
}
