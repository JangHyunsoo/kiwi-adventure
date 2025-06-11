using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventory : MonoBehaviour
{
    [SerializeField]
    private int equipment_skiil_book_count_ = 3;
    [SerializeField]
    private int have_skill_slot_count_ = 45;

    // private Skill[] skill_arr_; // Ω∫≈≥ Ω∫ø“ ¿Œµ¶ΩÃ»≠
    // private KeyValuePair<SkillSlotType, int>[] skill_slot_index_;

    [SerializeField]
    private SkillBook[] eqiupment_skill_book_arr_;
    [SerializeField]
    private Skill[] have_skill_arr_;

    public int eqiupment_skill_book_count { get => equipment_skiil_book_count_; }
    public int have_skill_slot_count { get => have_skill_slot_count_; }

    public void init()
    {
        initHaveSkillSlot();
        initEquipmentSlot();
        addSkillToEquipment(SkillDataBase.instance.getSkill(0, 1));
        //addSkillToEquipment(SkillDataBase.instance.getSkill(4, 1));
        setSkill(SkillDataBase.instance.getSkill(4, 1), 0, SkillSlotType.TWO);
        addSkillToHave(SkillDataBase.instance.getSkill(0, 0));
        addSkillToHave(SkillDataBase.instance.getSkill(1, 0));
        addSkillToHave(SkillDataBase.instance.getSkill(2, 0));
        addSkillToHave(SkillDataBase.instance.getSkill(3, 0));
    }

    private void initHaveSkillSlot()
    {
        have_skill_arr_ = new Skill[have_skill_slot_count_];
        for(int i = 0; i < have_skill_slot_count_; i++)
        {
            have_skill_arr_[i] = null;
        }
    }

    private void initEquipmentSlot()
    {
        eqiupment_skill_book_arr_ = new SkillBook[equipment_skiil_book_count_];
        for (int i = 0; i < equipment_skiil_book_count_; i++)
        {
            eqiupment_skill_book_arr_[i] = new SkillBook();
            eqiupment_skill_book_arr_[i].init();
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
        for (SkillSlotType slot_type = SkillSlotType.ONE; slot_type <= SkillSlotType.TREE; slot_type++)
        {
            for (int skill_idx = 0; skill_idx < eqiupment_skill_book_arr_[(int)slot_type].skill_size; skill_idx++)
            {
                Skill curr_skill = getSkill(skill_idx, slot_type);
                if (curr_skill == null)
                {
                    setSkill(_skill, skill_idx, slot_type);
                    return;
                }
            }
        }
    }

    public void createSkill(int _slot_no)
    {
        Skill curr_skill = getSkill(_slot_no, SkillSlotType.HAVE);

        if (!ItemInventory.instance.checkItems(curr_skill.skill_recipe_data.toDictionary()))
        {
            Debug.Log("cannot create skill");
        }
        else
        {
            ItemInventory.instance.useItems(curr_skill.skill_recipe_data.toDictionary());
            var max_slot = SkillManager.instance.searchSkillMaxLevel(curr_skill.skill_data.skill_no);
            if (_slot_no == max_slot.Value && SkillSlotType.HAVE == max_slot.Key)
            {
                curr_skill.level++;
            }
            else
            {
                getSkill(max_slot.Value, max_slot.Key).level++;
                clearSkill(_slot_no, SkillSlotType.HAVE);
            }
        }
    }

    public KeyValuePair<SkillSlotType, int> searchSkillMaxLevel(int _no)
    {
        KeyValuePair<SkillSlotType, int> max_slot = new KeyValuePair<SkillSlotType, int>(SkillSlotType.HAVE, -1);
        int max_level = -1;

        for (SkillSlotType slot_type = SkillSlotType.ONE; slot_type <= SkillSlotType.TREE; slot_type++)
        {
            for(int skill_idx = 0; skill_idx < eqiupment_skill_book_arr_[(int)slot_type].skill_size; skill_idx++)
            {
                Skill curr_skill = getSkill(skill_idx, slot_type);
                if (curr_skill != null)
                {
                    if (curr_skill.skill_data.skill_no == _no && curr_skill.level > max_level)
                    {
                        max_slot = new KeyValuePair<SkillSlotType, int>(slot_type, skill_idx);
                        max_level = curr_skill.level;
                    }
                }
            }
        }

        for (int i = 0; i < have_skill_arr_.Length; i++)
        {
            if (have_skill_arr_[i] != null)
            {
                if (have_skill_arr_[i].skill_data.skill_no == _no && have_skill_arr_[i].level > max_level)
                {
                    max_slot = new KeyValuePair<SkillSlotType, int>(SkillSlotType.HAVE, i);
                    max_level = have_skill_arr_[i].level;
                }
            }
        }

        return max_slot;
    }

    public void swapSkillSlot(int _one_slot_no, SkillSlotType _one_slot_type, int _other_slot_on, SkillSlotType _other_slot_type)
    {
        Skill one_skill = getSkill(_one_slot_no, _one_slot_type);
        Skill other_skill = getSkill(_other_slot_on, _other_slot_type);

        setSkill(one_skill, _other_slot_on, _other_slot_type);
        setSkill(other_skill, _one_slot_no, _one_slot_type);
    }

    public Skill getSkill(int _slot_no, SkillSlotType _slot_type)
    {
        if (_slot_type == SkillSlotType.HAVE) return have_skill_arr_[_slot_no];
        return eqiupment_skill_book_arr_[(int)_slot_type].getSkill(_slot_no);
    }

    public void setSkill(Skill _skill, int _slot_no, SkillSlotType _slot_type)
    {
        if (_slot_type == SkillSlotType.HAVE) have_skill_arr_[_slot_no] = _skill;
        else eqiupment_skill_book_arr_[(int)_slot_type].setSkill(_slot_no ,_skill);
    }

    public void clearSkill(int _slot_no, SkillSlotType _slot_type)
    {
        setSkill(null, _slot_no, _slot_type);
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

    public SkillBook getEquipmentBook(SkillSlotType _slot_type)
    {
        return eqiupment_skill_book_arr_[(int)_slot_type];
    }

    public Skill getEquipmentSkill(int _slot_no, SkillSlotType _slot_type)
    {
        return eqiupment_skill_book_arr_[(int)_slot_type].getSkill(_slot_no);
    }
}
