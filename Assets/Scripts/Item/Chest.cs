using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviour
{
    private static readonly int[] gacha_percentage_arr_ = { 60, 90, 97, 100 };
    private SkillRecipeData skill_recipe_;

    private Rarity rarity_;

    private Rarity min_rarity_;

    private int[] item_amount_arr_ = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

    private int item_count_;
    private int amount_ = 0;

    private bool is_open_ = false;
    public bool is_opne { get => is_open_; }


    [SerializeField]
    private Transform item_drop_pos_;
    [SerializeField]
    private GameObject drop_item_prefab_;

    private List<DropItemData> drop_item_data_list = new List<DropItemData>();

    public Chest(Rarity _min_rarity)
    {
        min_rarity_ = _min_rarity;
        setFixedItem();
        setRandomItem();
        setItem();
    }

    public Chest(Rarity _min_rarity, int[] _fixed_item)
    {
        min_rarity_ = _min_rarity;
        item_amount_arr_ = _fixed_item;
        setRandomItem();
        setItem(); 
    }

    public void setFixedItem()
    {
        item_amount_arr_[Random.RandomRange(0, 5)] = 1;
        item_amount_arr_[5] = Random.RandomRange(3, 6);
        item_amount_arr_[6] = Random.RandomRange(50, 150 + 1);
    }

    private void setSkillRecipe()
    {
        calculSkillRarityByMinRarity();
        // load SkillData for rarity 
    }

    private void calculSkillRarityByMinRarity()
    {
        int random_min = 0;
        if (min_rarity_ != Rarity.COMMON) random_min = gacha_percentage_arr_[(int)min_rarity_ - 1];

        int random_number = Random.RandomRange(random_min, gacha_percentage_arr_[gacha_percentage_arr_.Length - 1]);
        var rarity_list = Enum.GetValues(typeof(Rarity));

        for (int i = 0; i < rarity_list.Length; i++)
        {
            if (gacha_percentage_arr_[i] > random_number)
            {
                rarity_= (Rarity)rarity_list.GetValue(i);
            }
        }
        rarity_ = Rarity.COMMON;
    }

    private void setRandomItem()
    {
        // plus random item amount in item_amount_arr_
    }

    private void setItem()
    {
        for (int i = 0; i < item_amount_arr_.Length; i++)
        {
            if(item_amount_arr_[i] != 0)
            {
                drop_item_data_list.Add(ItemDataBase.instance.getDropItemData(i, item_amount_arr_[i]));
            }
        }

        Debug.Log(drop_item_data_list.Count);
    }

    public DropItemData getItem(int _index)
    {
        return drop_item_data_list[_index];
    }

    public void setIsOpen(bool _value)
    {
        is_open_ = _value;
    }

    public void debug()
    {
        Debug.Log(drop_item_data_list[0].item_data.name);


        Debug.Log(drop_item_data_list[1].item_data.name);
        Debug.Log(drop_item_data_list[2].item_data.name);
    }

}
