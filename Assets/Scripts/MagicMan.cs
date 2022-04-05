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

    private SpriteRenderer sprite_renderer;
    private Rigidbody2D rigidbody_;

    protected override void init()
    {
        base.init();
        target = PlayerManager.instance.player.transform;
        sprite_renderer = GetComponent<SpriteRenderer>();
        rigidbody_ = GetComponent<Rigidbody2D>();
        skills_.Add(SkillDataBase.instance.getSkill(0));
        skills_.Add(SkillDataBase.instance.getSkill(0));
    }

    public void Update()
    {
        enemyAI();
    }

    public void enemyAI()
    {
        dist = calculDistance();
        rigidbody_.velocity = Vector2.zero;

        if (!isAttack)
        {
            if (short_attack_distance >= dist)
            {
                isAttack = true;
                skills_[0].activate(transform.position, target.position, tag);
                Color color = sprite_renderer.color;
                color.a = 0.5f;
                sprite_renderer.color = color;
                StartCoroutine(attackShort());
            }
            else if (long_attack_dictance >= dist)
            {
                isAttack = true;
                skills_[1].activate(transform.position, target.position, tag);
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