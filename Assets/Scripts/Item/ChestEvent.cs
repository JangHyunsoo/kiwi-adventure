using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestEvent : InteractionEvent
{
    [SerializeField]
    private int[] fixed_items_;
    private int random_items_;

    private bool isOpen = false;

    [SerializeField]
    private Transform item_drop_pos_;

    [SerializeField]
    private GameObject drop_item_prefab_;
    
    private List<ItemData> drop_item_data_list = new List<ItemData>();

    public override void activate()
    {
       if(!isOpen)
        {
            setRandomItem();
            setChest();
            openChest();
            isOpen = true;


            for(int i = 0; i< drop_item_data_list.Count; i++)
            {
                Debug.Log(drop_item_data_list[i].item_name);
                Debug.Log(drop_item_data_list[i].item_amount);
            }
        }
    }

    private void setRandomItem()
    {
        random_items_ = Random.Range(3, 5);
    }

    private void setChest()
    {
        foreach (var index in fixed_items_)
        {
            drop_item_data_list.Add(ItemDataBase.instance.getItemData(fixed_items_[index]));
        }
        
        for(int i = 0; i < random_items_; i++)
        {
            drop_item_data_list.Add(ItemDataBase.instance.getItemData(3));
        }

        Debug.Log(drop_item_data_list.Count);


    }

    private void openChest()
    {
        var drop_pos = Utility.getChildsTransform(item_drop_pos_);


        for(int i = 0; i < drop_item_data_list.Count; i++)
        {
            var obj = GameObject.Instantiate(drop_item_prefab_, drop_pos[i].position, Quaternion.identity);
            obj.GetComponent<PickUpEvent>().updataItem(drop_item_data_list[i]);
        }
    }
}
