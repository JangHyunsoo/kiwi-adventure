using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected string team_;
    protected int damage_;
    protected Vector3 my_pos_;
    protected Vector3 target_pos_;
    protected float range_;
    protected float size_;
    protected float speed_;

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

    protected virtual void onHit(Collider2D collision) {}

    public void setData(SkillData _skill_data)
    {
        damage_ = _skill_data.skill_damage;
        range_ = _skill_data.casting_range;
        size_ = _skill_data.projectile_size;
        speed_ = _skill_data.projectile_speed;
        transform.localScale = Vector3.one * size_;

        Debug.Log(speed_);


        // add exception of not have sprite
        GetComponent<SpriteRenderer>().sprite = _skill_data.skill_image;
    }
}
