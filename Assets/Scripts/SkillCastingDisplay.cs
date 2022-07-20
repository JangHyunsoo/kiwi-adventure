using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCastingDisplay : MonoBehaviour
{
    [SerializeField]
    private Transform need_tr_;
    [SerializeField]
    private Transform curr_tr_;

    private Text[] need_casting_text_array_;
    private Text[] curr_casting_text_array_;

    private string curr_casting_str_ = "";

    public void init()
    {
        need_casting_text_array_ = need_tr_.GetComponentsInChildren<Text>();
        curr_casting_text_array_ = curr_tr_.GetComponentsInChildren<Text>();
        curr_casting_str_ = "";
        clearDisplay();
    }
    
    public void updateNeed(Skill _skill)
    {
        if (_skill != null)
        {
            string command = _skill.skill_data.command;

            clearNeed();

            for (int i = 0; i < command.Length; i++)
            {
                need_casting_text_array_[i].text = command[i].ToString();
            }
        }
        else
        {
            clearNeed();
        }
        
    }

    public void updateCurr(string _str)
    {
        curr_casting_str_ += _str;

        for (int i = 0; i < curr_casting_text_array_.Length; i++)
        {
            curr_casting_text_array_[i].text = "";
        }

        for (int i = 0; i < curr_casting_str_.Length; i++)
        {
            curr_casting_text_array_[i].text = curr_casting_str_[i].ToString();
        }

    }

    private void clearNeed()
    {
        for (int i = 0; i < need_casting_text_array_.Length; i++)
        {
            need_casting_text_array_[i].text = "";
        }
    }

    public void clearCurr()
    {
        for (int i = 0; i < curr_casting_text_array_.Length; i++)
        {
            curr_casting_text_array_[i].text = "";
        }
        curr_casting_str_ = "";
    }

    public void clearDisplay()
    {
        clearNeed();
        clearCurr();
    }
}
