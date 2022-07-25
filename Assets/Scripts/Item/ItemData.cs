using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
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
    private Sprite item_sprite_;
    public Sprite item_sprite { get => item_sprite_; set => item_sprite_ = value; }
}
