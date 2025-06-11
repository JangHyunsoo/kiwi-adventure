using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Utility.MonsterTag)
        {
            EnemyManager.instance.addTargetEnemey(collision.GetComponent<EnemyEntity>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Utility.MonsterTag)
        {
            EnemyManager.instance.removeTargetEnemey(collision.GetComponent<EnemyEntity>());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }
}
