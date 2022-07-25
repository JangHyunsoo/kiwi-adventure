using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpEvent : InteractionEvent
{
    private DropItemData drop_item_data_;
    public DropItemData drop_item_data { get => drop_item_data_; }

    public override void activate()
    {
        ItemInventory.instance.addItem(drop_item_data_);
        Destroy(this.gameObject);
    }

    public void updataItem(DropItemData _drop_item_data)
    {
        drop_item_data_ = _drop_item_data;
        GetComponent<SpriteRenderer>().sprite = _drop_item_data.item_data.item_sprite;
    }
}
