using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillBookData.asset", menuName = "SkillBookData")]
public class SkillBookData : ScriptableObject
{
    [System.Serializable]
    public class RandValue
    {
        [SerializeField] private SkillBookOption option_type;
        [SerializeField] private float min_value_ = 1f;
        [SerializeField] private float max_value_ = 1f;
        public float getRand()
        {
            return Random.RandomRange(min_value_, max_value_);
        }
    }
    [SerializeField]
    private int skill_book_no_;
    [SerializeField]
    private RandValue[] option_rand_value_arr_;
    [SerializeField]
    private int skill_slot_size_ = 3;
    [SerializeField]
    private Sprite skill_book_sprite_;

    /*
    private void initOptionRandValue()
    {
        var option_rand_value_list = new List<RandValue>();

        option_rand_value_list.Add(fire_damage_rand_value_);
        option_rand_value_list.Add(ice_damage_rand_value_);
        option_rand_value_list.Add(water_damage_rand_value_);
        option_rand_value_list.Add(eletric_damage_rand_value_);
        option_rand_value_list.Add(earth_damage_rand_value_);
        option_rand_value_list.Add(dark_damage_rand_value_);
        option_rand_value_list.Add(cool_time_rand_value_);
        option_rand_value_list.Add(critical_chance_rand_value_);
        option_rand_value_list.Add(critical_damage_rand_value_);

        // option_rand_value_arr_ = option_rand_value_list.ToArray();
    }

    private void initOptionValue()
    {
        option_value_arr_ = Enumerable.Repeat<float>(0, option_rand_value_arr_.Length).ToArray();
    }

    public void randOptionValue()
    {
        int[] shuffle_arr = Utility.getShuffleArray(option_value_arr_.Length);

        for (int i = 0; i < selection_option_size_; i++)
        {
            int rand_idx = shuffle_arr[i];
            option_value_arr_[rand_idx] = option_rand_value_arr_[rand_idx].getRand();
        }
    }
    */
}
