using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMan : EnemyEntity
{
    [SerializeField]
    private List<Skill> skills_ = new List<Skill>();

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private bool isAttack = false;

    [SerializeField]
    private double move_distance = 20f;
    [SerializeField]
    private double long_attack_dictance = 3f;
    [SerializeField]
    private double short_attack_distance = 1f;

    [SerializeField]
    private double dist = 0f;

    [SerializeField]
    private float fov_ = 360f;
    [SerializeField]
    private int ray_count_ = 100;
    [SerializeField]
    private float view_distance_ = 10f;

    private Vector3 origin;

    private SpriteRenderer sprite_renderer;
    private Rigidbody2D rigidbody_;

    public override void init()
    {
        base.init();
        sprite_renderer = GetComponent<SpriteRenderer>();
        rigidbody_ = GetComponent<Rigidbody2D>();
        skills_.Add(SkillDataBase.instance.getSkill(0, 1));
        skills_.Add(SkillDataBase.instance.getSkill(0, 1));
    }

    public void Update()
    {
        enemyAI();
    }

    public void enemyAI()
    {
        checkEnemy();
        rigidbody_.velocity = Vector2.zero;

        if(target == null)
        {
            return;
        }

        if (!isAttack)
        {
            dist = calculDistance();

            if (short_attack_distance >= dist)
            {
                isAttack = true;
                skills_[0].activate(this, target.position);
                Color color = sprite_renderer.color;
                color.a = 0.5f;
                sprite_renderer.color = color;
                StartCoroutine(attackShort());
            }
            else if (long_attack_dictance >= dist)
            {
                isAttack = true;
                skills_[1].activate(this, target.position);
                Color color = sprite_renderer.color;
                color.a = 0.5f;
                sprite_renderer.color = color;
                StartCoroutine(attackFireBall());
            }
            else if(move_distance >= dist)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            }
        }
    }

    private void checkEnemy()
    {
        int ray_count = ray_count_;
        float angle = 0f;
        float view_distance = view_distance_;
        float angle_increase = fov_ / ray_count_;

        origin = transform.position;
        target = null;

        for (int i = 0; i <= ray_count_; i++)
        {
            RaycastHit2D raycast = Physics2D.Raycast(origin, Utility.GetVectorFromAngle(angle), view_distance_, (-1) - (1 << LayerMask.NameToLayer("Monster")));

            if (raycast.collider != null)
            {
                if (raycast.collider.gameObject.tag == Utility.PlayerTag)
                {
                    target = raycast.collider.gameObject.transform;
                }
            }

            angle -= angle_increase;
        }
    }

    private IEnumerator attackShort()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
        Color color = sprite_renderer.color;
        color.a = 1f;
        sprite_renderer.color = color;
    }

    private IEnumerator attackFireBall()
    {
        yield return new WaitForSeconds(1f);
        Color color = sprite_renderer.color;
        color.a = 1f;
        sprite_renderer.color = color;
        isAttack = false;
    }

    private double calculDistance()
    {
        return Vector2.Distance(transform.position, target.position);
    }
}