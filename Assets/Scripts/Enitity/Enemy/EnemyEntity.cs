using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    private void Start()
    {
        init();
    }

    protected override void onDie()
    {
        EnemyManager.instance.removeEnemy(this);
        EnemyManager.instance.removeTargetEnemey(this);
        if (EnemyManager.instance.isEnemyEmpty())
        {
            StageManager.instance.clearRoom();
        }

        Destroy(this.gameObject);
    }
}