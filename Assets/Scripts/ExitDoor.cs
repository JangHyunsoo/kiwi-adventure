using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private int enter_id_;
    
    public int enter_id { get => enter_id_; set => enter_id_ = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StageManager.instance.MoveRoom(enter_id_);
            collision.gameObject.transform.position = StageManager.instance.getCurrStagePlayerSpawnPos();
            StageManager.instance.startBattle();
        }
    }
}
