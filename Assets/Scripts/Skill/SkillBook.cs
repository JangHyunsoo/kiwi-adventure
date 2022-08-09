using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillBook
{
    private SkillBookData skill_book_data_;
    private int skill_size_ = 3;
    private Skill[] skill_arr_;
    private float[] option_value_arr_;

    public int skill_size { get => skill_size_; }

    public SkillBook()
    {
        init();
    }

    public void init()
    {
        initSkillArr();
    }

    private void initSkillArr()
    {
        skill_arr_ = Enumerable.Repeat<Skill>(null, skill_size_).ToArray();
    }

    public void setSkill(int _no, Skill _skill)
    {
        skill_arr_[_no] = _skill;
    }

    public Skill getSkill(int _no)
    {
        return skill_arr_[_no];
    }
}

