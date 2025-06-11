using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    private static ItemDataBase _instance = null;

    public static ItemDataBase instance
    {
        get
        {
            if (_instance == null) { return null; }
            else { return _instance; }
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField]
    private ItemData[] item_data_arr_;

    public void init()
    {
        // not required
        Array.Sort(item_data_arr_, compare);
    }

    public ItemData getItemData(int _index_num)
    {
        return item_data_arr_[_index_num];
    }

    private int compare(ItemData _one, ItemData _other) 
    {
        if (_one.item_code > _other.item_code)
        {
            return 1;
        }
        else if (_one.item_code > _other.item_code)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public DropItemData getDropItemData(int _index, int _amount)
    {
        return new DropItemData(item_data_arr_[_index], _amount);
    }
}