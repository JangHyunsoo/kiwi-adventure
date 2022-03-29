using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEvent : InteractionEvent
{
    [SerializeField]
    private ItemData item_data_;
    public ItemData item_data { get => item_data_; set => item_data_ = item_data; }

    public override void activate()
    {
        ItemInventory.instance.addItem(item_data_);
        Destroy(this.gameObject);
    }

    public void updataItem(ItemData _item_data)
    {
        item_data_ = _item_data;
        GetComponent<SpriteRenderer>().sprite = item_data_.item_sprite;
    }
}
