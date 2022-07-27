using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject slot_prefab_;

    [SerializeField]
    private GameObject have_slot_parent_;
    [SerializeField]
    private GameObject equipment_slot_parent_;

    private SkillSlot[] have_skill_slot_arr_;
    private SkillSlot[] equipment_skill_slot_arr_;

    private bool is_activate_ = false;

    public void init()
    {
        setupHaveSlot();
        setupEquipmentSlot();
    }

    private void setupHaveSlot()
    {
        int have_slot_count = SkillManager.instance.have_skill_count;

        for(int i = 0; i < have_slot_count; i++)
        {
            GameObject slot = GameObject.Instantiate(slot_prefab_);
            slot.transform.SetParent(have_slot_parent_.transform);
        }

        have_skill_slot_arr_ = have_slot_parent_.GetComponentsInChildren<SkillSlot>();
        for (int i = 0; i < have_skill_slot_arr_.Length; i++)
        {
            have_skill_slot_arr_[i].slot_no = i;
        }
    }

    private void setupEquipmentSlot()
    {
        int equipment_slot_count = SkillManager.instance.eqiupment_skill_count;

        for (int i = 0; i < equipment_slot_count; i++)
        {
            GameObject slot = GameObject.Instantiate(slot_prefab_);
            slot.transform.SetParent(equipment_slot_parent_.transform);
        }

        equipment_skill_slot_arr_ = equipment_slot_parent_.GetComponentsInChildren<SkillSlot>();
        for (int i = 0; i < equipment_skill_slot_arr_.Length; i++)
        {
            equipment_skill_slot_arr_[i].slot_no = i;
            equipment_skill_slot_arr_[i].setupEquipmentSlot();
        }
    }

    public void updateSkillSlot()
    {
        for (int i = 0; i < have_skill_slot_arr_.Length; i++)
        {
            if (have_skill_slot_arr_[i].skill != null)
            {
                have_skill_slot_arr_[i].updateSkill();
            }
        }

        for (int i = 0; i < equipment_skill_slot_arr_.Length; i++)
        {
            if (equipment_skill_slot_arr_[i].skill != null)
            {
                equipment_skill_slot_arr_[i].updateSkill();
            }
        }
    }

    public Skill getEquipmentSkill(int _idx)
    {
        return equipment_skill_slot_arr_[_idx].skill;
    }

    public Skill searchSkillMaxLevel(int _no)
    {
        List<Skill> result = new List<Skill>();

        for (int i = 0; i < equipment_skill_slot_arr_.Length; i++)
        {
            if (equipment_skill_slot_arr_[i].skill != null)
            {
                if (equipment_skill_slot_arr_[i].skill.skill_data.skill_no == _no)
                {
                    result.Add(equipment_skill_slot_arr_[i].skill);
                }
            }
        }

        for (int i = 0; i < have_skill_slot_arr_.Length; i++)
        {
            if (have_skill_slot_arr_[i].skill != null)
            {
                if (have_skill_slot_arr_[i].skill.skill_data.skill_no == _no)
                {
                    result.Add(have_skill_slot_arr_[i].skill);
                }
            }
        }

        result.Sort(delegate (Skill one, Skill other)
        {
            if (one.level < other.level) return 1;
            else if (one.level > other.level) return -1;
            else return 0;
        });

        return result[0];
    }

    public void sortSkill()
    {
        for (int i = 0; i < have_skill_slot_arr_.Length; i++)
        {
            for (int j = 0; j < have_skill_slot_arr_.Length; j++)
            {
                if (compareSkill(have_skill_slot_arr_[i].skill, have_skill_slot_arr_[j].skill) == 1)
                {
                    swapHaveSkillSlot(i, j);
                }
            }
        }
    }

    private int compareSkill(Skill one, Skill other)
    {
        if (one == null) return -1;
        else if (other == null) return 1;
        else if (one.level == other.level) return one.skill_data.skill_name.CompareTo(other.skill_data.skill_name);
        else return one.level.CompareTo(other.level);
    }

    // contain update
    private void swapHaveSkillSlot(int _idx1, int _idx2)
    {
        Skill skill1 = have_skill_slot_arr_[_idx1].skill;
        Skill skill2 = have_skill_slot_arr_[_idx2].skill;

        have_skill_slot_arr_[_idx1].skill = skill2;
        have_skill_slot_arr_[_idx2].skill = skill1;

        have_skill_slot_arr_[_idx1].updateSkill();
        have_skill_slot_arr_[_idx2].updateSkill();
    }

    public void setActivate(bool _condition)
    {
        is_activate_ = _condition;
        gameObject.SetActive(_condition);
    }
}
