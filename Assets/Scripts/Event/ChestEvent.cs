using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestEvent : InteractionEvent
{
    private Chest chest_;
    [SerializeField]
    private Transform drop_parent_tr_;
    [SerializeField]
    private GameObject drop_item_prefab_;
    [SerializeField]
    private GameObject drop_recipe_prefab_;

    [SerializeField]
    public Transform[] drop_pos;

    public override void activate()
    {
        if(!chest_.is_opne)
        {
            openChest();
        }
    }

    public override void init()
    {
        chest_ = new Chest(Rarity.COMMON);
        drop_pos = Utility.getChildsTransform(drop_parent_tr_);
    }


    private void openChest()
    {
        dropSkillRecipe();
        dropItem();
    }

    private void dropSkillRecipe()
    {
        var obj = GameObject.Instantiate(drop_recipe_prefab_, drop_pos[0].position, Quaternion.identity);
        obj.GetComponent<SkillRecipePickUpEvent>().updateSkillRecipe(chest_.getSkillRecipe());
    }

    private void dropItem()
    {
        for (int i = 0; i < chest_.getItemCount(); i++)
        {
            var obj = GameObject.Instantiate(drop_item_prefab_, drop_pos[i + 1].position, Quaternion.identity);
            obj.GetComponent<ItemPickUpEvent>().updataItem(chest_.getItem(i));
        }

        chest_.setIsOpen(true);
    }
}
