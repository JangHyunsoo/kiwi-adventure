using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillCoolTimeTable : MonoBehaviour
{
    private HashSet<int> cool_time_skill_idx_set_ = new HashSet<int>();
    private float[] curr_skill_cool_time_arr_;
    private float[] start_skill_cool_time_arr_;

    public void init()
    {
        curr_skill_cool_time_arr_ = Enumerable.Repeat(0f, SkillDataBase.instance.skill_count).ToArray();
        start_skill_cool_time_arr_ = Enumerable.Repeat(0f, SkillDataBase.instance.skill_count).ToArray();
        cool_time_skill_idx_set_.Clear();
    }

    private void Update()
    {
        for (int i = 0; i < cool_time_skill_idx_set_.Count; i++)
        {
            updateSkillCoolTime(cool_time_skill_idx_set_.ElementAt(i));
        }
    }

    public void startCoolTime(int _skill_no, float _cool_time) 
    {
        curr_skill_cool_time_arr_[_skill_no] = _cool_time;
        start_skill_cool_time_arr_[_skill_no] = _cool_time;
        cool_time_skill_idx_set_.Add(_skill_no);
    }

    private void updateSkillCoolTime(int _skill_no)
    {
        curr_skill_cool_time_arr_[_skill_no] -= Time.deltaTime;
        if(curr_skill_cool_time_arr_[_skill_no] <= 0f)
        {
            curr_skill_cool_time_arr_[_skill_no] = 0f;
            cool_time_skill_idx_set_.Remove(_skill_no);
        }
    }

    public float getSkillCoolTimeAmount(int _skill_no)
    {
        return curr_skill_cool_time_arr_[_skill_no] / start_skill_cool_time_arr_[_skill_no];
    }

    public bool isReady(int _skill_no)
    {
        return !cool_time_skill_idx_set_.Contains(_skill_no);
    }
}
