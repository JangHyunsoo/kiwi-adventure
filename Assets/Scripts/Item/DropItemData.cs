using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemData : MonoBehaviour
{
    private ItemData item_data_;
    public ItemData item_data { get => item_data_; }
    private int amount_;
    public int amount { get => amount_; }

    public DropItemData(ItemData _item_data, int _amount)
    {
        item_data_ = _item_data;
        amount_ = _amount;
    }

    public void setAmount(int _value)
    {
        amount_ = _value;
    }
}
