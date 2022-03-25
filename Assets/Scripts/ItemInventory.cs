using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    private static ItemInventory _instance = null;

    [SerializeField]
    private Dictionary<int, int> inventory_ = new Dictionary<int, int>();

    public Dictionary<int, int> inventory { get => inventory_; }

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

    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            inventory_[i] = 0;
        }
    }

   
    public void addItem(ItemData _item_data)
    {
        inventory_[_item_data.item_code] += _item_data.item_amount;
    }
    
}
