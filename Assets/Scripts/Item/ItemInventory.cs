using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    private static ItemInventory _instance = null;

    public static ItemInventory instance
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
    private Dictionary<int, int> inventory_ = new Dictionary<int, int>();
    public Dictionary<int, int> inventory { get => inventory_; }

    [SerializeField]
    private ElementDisplay element_display_cp_;

    public void init()
    {
        for(int i = 0; i < 10; i++)
        {
            inventory_[i] = 100;
        }
        updateDisplay();
    }

    public void addItem(DropItemData _drop_item_data)
    {
        inventory_[_drop_item_data.item_data.item_code] += _drop_item_data.amount;
        updateDisplay();
    }

    public void useItem(DropItemData _drop_item_data)
    {
        inventory_[_drop_item_data.item_data.item_code] -= _drop_item_data.amount;
        updateDisplay();
    }

    public void useItems(Dictionary<int,int> _used_items)
    {
        foreach(var item in _used_items)
        {
            inventory_[item.Key] -= item.Value;
        }
        updateDisplay();
    }

    public bool checkItem(DropItemData _used_item)
    {

        if (inventory_[_used_item.item_data.item_code] < _used_item.amount)
        {
            return false;
        }
        return true;
    }

    public bool checkItems(Dictionary<int, int> _used_items)
    {
        foreach (var item in _used_items)
        {
            if (inventory_[item.Key] < item.Value)
            {
                return false;
            }
        }

        return true;
    }

    private void updateDisplay()
    {
        element_display_cp_.updateElementDisplay();
    }
}