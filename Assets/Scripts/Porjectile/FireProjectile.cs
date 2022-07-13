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
                collision.GetComponent<Entity>().hitDamage(1);
                collision.GetComponent<BuffTable>().addBuff(new Burn(1));
                Destroy(gameObject);
            }
        }
    }
}
