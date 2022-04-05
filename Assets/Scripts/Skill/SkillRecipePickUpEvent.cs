using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRecipePickUpEvent : InteractionEvent
{
    private SkillData skill_data_;
    public SkillData skill_data;

    public override void activate()
    {

    }

    public void setRandomSkillData(SkillRarity _skill_rarity)
    {
        // load radom skill data at skilldb 
    }
}
