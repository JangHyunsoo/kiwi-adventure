using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventory : MonoBehaviour
{
    [SerializeField]
    private int eqiupment_skill_slot_count_ = 5;
    [SerializeField]
    private int have_skill_slot_count_ = 15;

    private Skill[] eqiupment_skill_arr_;
    private Skill[] have_skill_arr_;

    public int eqiupment_skill_slot_count { get => eqiupment_skill_slot_count_; }
    public int have_skill_slot_count { get => have_skill_slot_count_; }

    private void Update()
    {
        foreach (Skill skill in eqiupment_skill_arr_)
        {
            if(skill != null)
            {
                if (!skill.is_ready)
                {
                    skill.updateCoolTime();
                }
            }

        }

        foreach (var skill in have_skill_arr_)
        {
            if (skill != null)
            {
                if (!skill.is_known && !skill.is_ready)
                {
                    skill.updateCoolTime();
                }
            }        }
    }

    public void init()
    {
        initHaveSlot();
        initEquipmentSlot();
        addSkillToHave(SkillDataBase.instance.getSkill(0, 0));
        addSkillToHave(SkillDataBase.instance.getSkill(0, 0));
        addSkillToHave(SkillDataBase.instance.getSkill(1, 0));
        addSkillToEquipment(SkillDataBase.instance.getSkill(0, 1));
    }

    private void initHaveSlot()
    {
        have_skill_arr_ = new Skill[have_skill_slot_count_];
        for(int i = 0; i < have_skill_slot_count_; i++)
        {
            have_skill_arr_[i] = null;
        }
    }

    private void initEquipmentSlot()
    {
        eqiupment_skill_arr_ = new Skill[eqiupment_skill_slot_count_];
        for (int i = 0; i < eqiupment_skill_slot_count_; i++)
        {
            eqiupment_skill_arr_[i] = null;
        }
    }

    public void addSkillToHave(Skill _skill)
    {
        for (int i = 0; i < have_skill_arr_.Length; i++)
        {
            if (have_skill_arr_[i] == null)
            {
                have_skill_arr_[i] = _skill;
                return;
            }
        }
    }

    public void addSkillToEquipment(Skill _skill)
    {
        for (int i = 0; i < eqiupment_skill_arr_.Length; i++)
        {
            if (eqiupment_skill_arr_[i] == null)
            {
                eqiupment_skill_arr_[i] = _skill;
                return;
            }
        }
    }

    public void createSkill(int _no, bool _is_eqiupment)
    {
        Skill curr_skill = getSkill(_no, _is_eqiupment);


        if (!ItemInventory.instance.checkItems(curr_skill.skill_recipe_data.toDictionary()))
        {
            Debug.Log("cannot create skill");
        }
        else
        {
            ItemInventory.instance.useItems(curr_skill.skill_recipe_data.toDictionary());
            Skill max_skill = SkillManager.instance.searchSkillMaxLevel(curr_skill.skill_data.skill_no);
            if (curr_skill == max_skill)
            {
                curr_skill.level++;
            }
            else
            {
                max_skill.level++;
                clearSkill(_no, _is_eqiupment);
            }
        }
    }

    public Skill searchSkillMaxLevel(int _no)
    {
        List<Skill> result = new List<Skill>();

        for (int i = 0; i < eqiupment_skill_arr_.Length; i++)
        {
            if (eqiupment_skill_arr_[i] != null)
            {
                if (eqiupment_skill_arr_[i].skill_data.skill_no == _no)
                {
                    result.Add(eqiupment_skill_arr_[i]);
                }
            }
        }

        for (int i = 0; i < have_skill_arr_.Length; i++)
        {
            if (have_skill_arr_[i] != null)
            {
                if (have_skill_arr_[i].skill_data.skill_no == _no)
                {
                    result.Add(have_skill_arr_[i]);
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

    public void swapSkillSlot(SkillSlot _one, SkillSlot _other)
    {
        Skill one_skill = getSkill(_one.slot_no, _one.is_equipment_slot);
        Skill other_skill = getSkill(_other.slot_no, _other.is_equipment_slot);

        setSkill(one_skill, _other.slot_no, _other.is_equipment_slot);
        setSkill(other_skill, _one.slot_no, _one.is_equipment_slot);
    }

    public Skill getSkill(int no_, bool is_eq)
    {
        if (is_eq) return eqiupment_skill_arr_[no_];
        return have_skill_arr_[no_];
    }

    public void setSkill(Skill _skill, int no_, bool _is_eq)
    {
        if (_is_eq) eqiupment_skill_arr_[no_] = _skill;
        else have_skill_arr_[no_] = _skill;
    }

    public void clearSkill(int no_, bool _is_eq)
    {
        setSkill(null, no_, _is_eq);
    }

    public void sortSkill()
    {
        Array.Sort(have_skill_arr_, compareSkill);
    }

    private int compareSkill(Skill one, Skill other)
    {
        if (one == null) return -1;
        else if (other == null) return 1;
        else if (one.level == other.level) return one.skill_data.skill_name.CompareTo(other.skill_data.skill_name);
        else return one.level.CompareTo(other.level);
    }

    public Skill getEquipmentSkill(int _idx)
    {
        return eqiupment_skill_arr_[_idx];
    }
}
