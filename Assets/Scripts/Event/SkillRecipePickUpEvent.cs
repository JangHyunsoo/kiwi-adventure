using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRecipePickUpEvent : InteractionEvent
{
    private SkillRecipeData skill_recipe_data_;
    public SkillRecipeData skill_recipe_data;

    public override void activate()
    {
        SkillManager.instance.addSkill(SkillDataBase.instance.getSkill(skill_recipe_data_.skill_no, 0));
        Destroy(gameObject);
    }

    public void updateSkillRecipe(SkillRecipeData _skill_recipe_data)
    {
        skill_recipe_data_ = _skill_recipe_data;
    }
}
