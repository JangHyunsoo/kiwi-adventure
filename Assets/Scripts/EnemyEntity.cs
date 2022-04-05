using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    protected override void onDie()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        EnemyManager.instance.removeEnemy(this);
        EnemyManager.instance.removeTargetEnemey(this);
        if (EnemyManager.instance.isEnemyEmpty())
        {
            StageManager.instance.clearStage();
        }
    }
}