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
    public Transform[] drop_pos;

    public override void activate()
    {
        if(!chest_.is_opne)
        {
            chest_.debug();
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
        for (int i = 0; i < drop_pos.Length; i++)
        {
            var obj = GameObject.Instantiate(drop_item_prefab_, drop_pos[i].position, Quaternion.identity);
            obj.GetComponent<ItemPickUpEvent>().updataItem(chest_.getItem(i));
        }

        chest_.setIsOpen(true);
    }
}
