using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField]
    private ItemType item_type_; 
    public ItemType item_type { get => item_type_; set => item_type_ = value; }
    [SerializeField]
    private string item_name_;
    public string item_name { get => item_name_; set => item_name_ = value; }
    [SerializeField]
    private int item_code_;
    public int item_code { get => item_code_; set => item_code_ = value; }
    [SerializeField]
    private int item_amount_;
    public int item_amount { get => item_amount_; set => item_amount_ = value; }

    public virtual void activate() {}
}
