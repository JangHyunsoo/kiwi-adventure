using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBookInfoCardUI : MonoBehaviour
{
    private int curr_book_no_ = 0;
    private SkillBook curr_skill_book_;

    [SerializeField]
    private Image curr_book_image_;
    [SerializeField]
    private Text curr_book_name_;
    [SerializeField]
    private Text curr_book_info_;
    [SerializeField]
    private Text[] curr_book_option_arr_;

    private Dictionary<SkillBookOption, string> skill_book_option_string_dic_ = new Dictionary<SkillBookOption, string>()
    {
        {SkillBookOption.FIRE_DAMAGE, "Fire Damage Percent" },
        {SkillBookOption.ICE_DAMAGE, "Ice Damage Percent" },
        {SkillBookOption.WATER_DAMAGE, "Water Damage Percent" },
        {SkillBookOption.ELETRIC_DAMAGE, "Electric Damage Percent" },
        {SkillBookOption.EARTH_DAMAGE, "Earth Damage Percent" },
        {SkillBookOption.DARK_DAMAMGE, "Dark Damage Percent" },
        {SkillBookOption.COOL_TIME, "Cool Time Percent" },
        {SkillBookOption.CRITICAL_CHANCE, "Critical Chance Percent" },
        {SkillBookOption.CRITICAL_DAMAGE, "Critical Damage Percent" }
    };

    private void Update()
    {
        curr_skill_book_ = SkillManager.instance.getEquipmentBook(curr_book_no_);
        updateSkillBook();
    }

    public void setBookNo(int _book_no)
    {
        curr_book_no_ = _book_no;
        curr_skill_book_ = SkillManager.instance.getEquipmentBook(curr_book_no_);
    }

    private void updateSkillBook()
    {
        curr_book_image_.color = curr_skill_book_.skill_book_data.skill_book_color;
        curr_book_name_.text = curr_skill_book_.skill_book_data.skill_book_name;
        curr_book_info_.text = curr_skill_book_.skill_book_data.skill_book_info;
        activateOffOptionText();
        var curr_book_option = curr_skill_book_.option_value_arr;

        for (int i = 0; i < curr_book_option.Length; i++)
        {
            curr_book_option_arr_[i].text = skill_book_option_string_dic_[curr_book_option[i].Key] + " : " + curr_book_option[i].Value;
            curr_book_option_arr_[i].gameObject.active = true;
        }
    }

    private void activateOffOptionText()
    {
        foreach (var option_text in curr_book_option_arr_)
        {
            option_text.gameObject.active = false;
        }
    }

    public void changeSkillBookDataRandom()
    {
        curr_skill_book_.changeSkillBookDataRandom();
    }

    public void changeSkillOption()
    {
        curr_skill_book_.changeSkillOption();
    }
}
