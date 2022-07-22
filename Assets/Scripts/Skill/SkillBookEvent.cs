using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SkillBookEvent : InteractionEvent
{
    [SerializeField]
    private SkillRecipePickUpEvent[] drop_skill_recipe_list_;
    private SkillRarity min_skill_rarity_;
    private SkillRarity[] skill_rarity_list_ = new SkillRarity[MAX_SKILLBOOK_SIZE];
    private int[] gacha_percentage_ = { 60, 90, 97, 100 };

    private const int MAX_SKILLBOOK_SIZE = 3;


    // 너의 방법 -> 레어도 설정 -> 스킬 집어넣기

    public override void activate()
    {

    }

    public override void init()
    {
    }

    public void setup()
    {
      
    }


    public void setMinRarity(SkillRarity _skill_book_rarity)
    {
        min_skill_rarity_ = _skill_book_rarity;
    }


    public void setSkill()
    {
        for(int i = 0; i < MAX_SKILLBOOK_SIZE; i++)
        {
            drop_skill_recipe_list_[i].setRandomSkillData(calculRandomSkillRarity(skill_rarity_list_[i]));
        }
    }

    private SkillRarity calculRandomSkillRarity(SkillRarity _min_rarity)
    {
        int random_min = 0;
        if (_min_rarity != SkillRarity.COMMON) random_min = gacha_percentage_[(int)_min_rarity - 1];

        int random_number = Random.RandomRange(random_min, gacha_percentage_[gacha_percentage_.Length - 1]);
        var rarity_list = Enum.GetValues(typeof(SkillRarity));

        for (int i = 0; i < rarity_list.Length; i++)
        {
            if (gacha_percentage_[i] > random_number)
            {
                return (SkillRarity)rarity_list.GetValue(i);
            }
        }
        return SkillRarity.COMMON;
    }
}
