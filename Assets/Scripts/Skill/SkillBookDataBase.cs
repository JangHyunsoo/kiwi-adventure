using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBookDataBase : MonoBehaviour
{
    private static SkillBookDataBase _instance;
    public static SkillBookDataBase instance
    {
        get
        {
            if (_instance == null) { return null; }
            else { return _instance; }
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField]
    private SkillBookData[] skill_book_data_arr_;

    public void init()
    {
        Array.Sort(skill_book_data_arr_, (SkillBookData one, SkillBookData other) => {return one.skill_book_no.CompareTo(other.skill_book_no);});
    }

    public SkillBookData getSkillBookData(int _no)
    {
        return skill_book_data_arr_[_no];
    }

    public SkillBookData getSkillBookDataWithRandomIdx()
    {
        return Utility.getRandomValueInArray(skill_book_data_arr_);
    }
}
