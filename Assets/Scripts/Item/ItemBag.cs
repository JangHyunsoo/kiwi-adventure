using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBag : MonoBehaviour
{
    [SerializeField]
    private Image[] images;
    [SerializeField]
    private Text[] texts;


    public void Start()
    {
        images = GetComponentsInChildren<Image>();
        texts = GetComponentsInChildren<Text>();

        for (int i = 0; i< 10; i++)
        {
            images[i].sprite = ItemDataBase.instance.getItemData(i).item_sprite;
            texts[i].text = ItemInventory.instance.inventory[i].ToString();
        }
    }
}
