using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MoveProjectile
{

    protected override void onHit(Collider2D collision)
    {
        if (collision.tag != team_)
        {
            if (collision.tag == "Player" || collision.tag == "Monster")
            {
                collision.GetComponent<Entity>().hitDamage(skill_data_.skill_damage);
                collision.GetComponent<BuffTable>().addBuff(new Burn(1));
                Destroy(gameObject);
            }
        }
    }
}
