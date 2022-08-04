using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEquipmentBookSlotUI : MonoBehaviour
{
    
    private SkillEquipmentSkillSlotUI[] skill_slot_arr_;

    public void init()
    {
        skill_slot_arr_ = transform.GetComponentsInChildren<SkillEquipmentSkillSlotUI>();
    }

    public void updateSkillSlots()
    {
        foreach (var skill_slot in skill_slot_arr_)
        {
        }
    }
}
