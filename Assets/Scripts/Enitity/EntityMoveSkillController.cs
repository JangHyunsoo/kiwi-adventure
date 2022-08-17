using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveSkillController : MonoBehaviour
{
    private Rigidbody2D rb_;
    private EntityMovement movement_;
    private Vector3 target_pos_;
    private GameObject projectile_;
    private float skill_speed_;


    private void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        movement_ = GetComponent<EntityMovement>();
    }

    private void FixedUpdate ()
    {
        if(movement_.is_casting)
        {
            moveSkill();

            if (Vector3.Distance(transform.position, target_pos_) <= Time.deltaTime * 2f)
            {
                // projectile activate
                // entity movement init
                transform.position = target_pos_;
                reset();
            }
        }
    }

    public void startSkillMove(Vector3 _target_pos, GameObject _projectile, float _speed)
    {
        target_pos_ = _target_pos;
        projectile_ = _projectile;
        skill_speed_ = _speed;
        movement_.setCastingState(true);
    }

    // 초기화랑 실행이 같이 되는 느낌이라... 그런가ㅋㅋㅋ
    
    private void reset()
    {
        target_pos_ = Vector3.zero;
        projectile_ = null;
        movement_.reset();
        movement_.setCastingState(false);
    }

    private void moveSkill()
    {
        if (Vector2.Distance(target_pos_, transform.position) <= Time.deltaTime * skill_speed_)
        {
            rb_.MovePosition(target_pos_);
        }
        else
        {
            Vector2 dir = (target_pos_ - transform.position).normalized * Time.deltaTime * skill_speed_;
            rb_.MovePosition(rb_.position + dir);
         }
    }

}
