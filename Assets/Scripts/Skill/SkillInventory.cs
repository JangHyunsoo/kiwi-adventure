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

    [SerializeField]
    private SkillBook[] eqiupment_skill_book_arr_;
    [SerializeField]
    private Skill[] have_skill_arr_;

    public int eqiupment_skill_book_count { get => equipment_skiil_book_count_; }
    public int have_skill_slot_count { get => have_skill_slot_count_; }

    private void Update()
    {
        for (int book_idx = 0; book_idx < eqiupment_skill_book_arr_.Length; book_idx++)
        {
            for (int skill_idx = 0; skill_idx < eqiupment_skill_book_arr_[book_idx].skill_size; skill_idx++)
            {
                Skill curr_skill = getSkill(skill_idx, book_idx);
                if (curr_skill != null)
                {
                    curr_skill.updateCoolTime();
                }
            }
        }

        for (int i = 0; i < have_skill_arr_.Length; i++)
        {
            Skill curr_skill = getSkill(i, -1);
            if (curr_skill != null)
            {
                curr_skill.updateCoolTime();
            }
        }
    }

    public void init()
    {
        initHaveSkillSlot();
        initEquipmentSlot();
        addSkillToHave(SkillDataBase.instance.getSkill(0, 1));
        addSkillToHave(SkillDataBase.instance.getSkill(0, 0));
        addSkillToHave(SkillDataBase.instance.getSkill(1, 0));
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

    public void createSkill(int _slot_no, int _book_no)
    {
        Skill curr_skill = getSkill(_slot_no, _book_no);

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
                clearSkill(_slot_no, _book_no);
            }
        }
    }

    public Skill searchSkillMaxLevel(int _no)
    {
        List<Skill> result = new List<Skill>();

        for (int book_idx = 0; book_idx < eqiupment_skill_book_arr_.Length; book_idx++)
        {
            for(int skill_idx = 0; skill_idx < eqiupment_skill_book_arr_[book_idx].skill_size; skill_idx++)
            {
                Skill curr_skill = getSkill(skill_idx, book_idx);
                if (curr_skill != null)
                {
                    if (curr_skill.skill_data.skill_no == _no)
                    {
                        result.Add(curr_skill);
                    }
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

    public void swapSkillSlot(SkillInventorySkillSlotUI _one, SkillInventorySkillSlotUI _other)
    {
        Skill one_skill = getSkill(_one.slot_no, _one.book_no);
        Skill other_skill = getSkill(_other.slot_no, _other.book_no);

        setSkill(one_skill, _other.slot_no, _other.book_no);
        setSkill(other_skill, _one.slot_no, _one.book_no);
    }

    public Skill getSkill(int _slot_no, int _book_no)
    {
        if (_book_no == -1) return have_skill_arr_[_slot_no];
        return eqiupment_skill_book_arr_[_book_no].getSkill(_slot_no);
    }

    public void setSkill(Skill _skill, int _slot_no, int _book_no)
    {
        if (_book_no == -1) have_skill_arr_[_slot_no] = _skill;
        else eqiupment_skill_book_arr_[_book_no].setSkill(_slot_no ,_skill);
    }

    public void clearSkill(int _slot_no, int _book_no)
    {
        setSkill(null, _slot_no, _book_no);
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

    public SkillBook getEquipmentBook(int _no)
    {
        return eqiupment_skill_book_arr_[_no];
    }

    public Skill getEquipmentSkill(int _slot_no, int _book_no)
    {
        return eqiupment_skill_book_arr_[_book_no].getSkill(_slot_no);
    }
}
