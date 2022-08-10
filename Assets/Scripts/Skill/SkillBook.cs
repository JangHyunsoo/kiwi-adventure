using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillBook
{
    private Skill[] skill_arr_;
    private SkillBookData skill_book_data_;
    private Dictionary<SkillBookOption, float> option_value_dic_ = new Dictionary<SkillBookOption, float>();

    public SkillBookData skill_book_data { get => skill_book_data_; }
    public KeyValuePair<SkillBookOption, float>[] option_value_arr { get => option_value_dic_.ToArray(); }

    private int skill_size_ = 3;
    public int skill_size { get => skill_size_; }

    public SkillBook()
    {
        init();
    }

    public void init()
    {
        skill_book_data_ = SkillBookDataBase.instance.getSkillBookData(0);
        initSkillBookOption();
        initSkillArr();
    }

    private void initSkillBookOption()
    {
        calSkillBookOptin();
    }

    private void initSkillArr()
    {
        skill_arr_ = Enumerable.Repeat<Skill>(null, skill_size_).ToArray();
    }

    private void calSkillBookOptin()
    {
        option_value_dic_.Clear();
        foreach (var rand_value in skill_book_data_.essential_option_rand_value_arr)
        {
            option_value_dic_[rand_value.option_type] = rand_value.getRand();
        }

        int[] additional_idx_arr = Utility.getShuffleArray(skill_book_data_.additional_option_rand_value_arr.Length);

        for(int i = 0; i < skill_book_data_.additional_option_size; i++)
        {
            var curr_option = skill_book_data_.additional_option_rand_value_arr[i];
            option_value_dic_[curr_option.option_type] = curr_option.getRand();
        }
    }

    public void setSkill(int _no, Skill _skill)
    {
        skill_arr_[_no] = _skill;
    }

    public Skill getSkill(int _no)
    {
        return skill_arr_[_no];
    }

    public void changeSkillBookDataRandom()
    {
        skill_book_data_ = SkillBookDataBase.instance.getSkillBookDataWithRandomIdx();
        calSkillBookOptin();
    }

    public void changeSkillOption()
    {
        calSkillBookOptin();
    }
}

