using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField]
    private int enter_id_;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.transform.position = StageManager.instance.getEnterDoorPosition(enter_id_);
        }
    }
}
