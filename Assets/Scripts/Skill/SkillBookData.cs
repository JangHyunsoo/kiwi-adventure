using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillBookData.asset", menuName = "SkillBookData")]
public class SkillBookData : ScriptableObject
{
    [System.Serializable]
    public class RandValue
    {
        [SerializeField] 
        private SkillBookOption option_type_;
        [SerializeField] 
        private float min_value_ = 1f;
        [SerializeField] 
        private float max_value_ = 1f;

        public SkillBookOption option_type { get => option_type_; }

        public float getRand()
        {
            return (float)System.Math.Round(Random.RandomRange(min_value_, max_value_), 1);
        }
    }
    [SerializeField]
    private int skill_book_no_;
    [SerializeField]
    private string skill_book_name_;
    [SerializeField]
    private string skill_book_info_;
    [SerializeField]
    private RandValue[] essential_option_rand_value_arr_;
    [SerializeField]
    private RandValue[] additional_option_rand_value_arr_;
    [SerializeField]
    private int additional_option_size_;
    [SerializeField]
    private int skill_slot_size_ = 3;
    [SerializeField]
    private Color skill_book_color_ = Color.white;
    //private Sprite skill_book_sprite_;

    public int skill_book_no { get => skill_book_no_; }
    public string skill_book_name { get => skill_book_name_; }
    public string skill_book_info { get => skill_book_info_; }
    public RandValue[] essential_option_rand_value_arr { get => essential_option_rand_value_arr_; }
    public RandValue[] additional_option_rand_value_arr { get => additional_option_rand_value_arr_; }
    public int additional_option_size { get => additional_option_size_; }
    public int skill_slot_size { get => skill_slot_size_; }
    public Color skill_book_color { get => skill_book_color_; }

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
