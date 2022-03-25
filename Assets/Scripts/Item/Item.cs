using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemData _item_data;
    public ItemData item_data { get => _item_data; set => _item_data = item_data; }
}
