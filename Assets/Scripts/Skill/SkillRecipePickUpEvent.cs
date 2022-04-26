using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRecipePickUpEvent : InteractionEvent
{
    private SkillData skill_data_; // 드랍되있는 스프라이트 바꾸는 용
    public SkillData skill_data;

    public override void activate()
    {
        SkillInventory.instance.AcquireSkillToHave(SkillDataBase.instance.getSkillRecipe(skill_data_.skill_no));
    }

    public void setRandomSkillData(SkillRarity _skill_rarity)
    {
        // load radom skill data at skilldb 
    }
}
