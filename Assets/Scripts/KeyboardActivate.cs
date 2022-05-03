using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardActivate : MonoBehaviour
{
    [SerializeField]
    private KeyCode skill_inventory_key_;
    [SerializeField]
    private GameObject skill_inventory_;
    private bool skill_inventory_state_;

    void Update()
    {
        if (Input.GetKeyDown(skill_inventory_key_))
        {
            skill_inventory_state_ = !skill_inventory_.active;
            skill_inventory_.active = skill_inventory_state_;
        }
        if(skill_inventory_state_ && Input.GetKeyDown(KeyCode.Escape))
        {
            skill_inventory_.active = false;
            skill_inventory_state_ = false;
        }
    }
}
