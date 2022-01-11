using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField]
    private PlayerData player_data_;
    public PlayerData player_data { get => player_data_; }

    private int current_hp_;
    public int current_hp { get => current_hp_; set => current_hp_ = value; }

    private void Start()
    {
        init();
    }
    private void init()
    {
        current_hp = player_data.max_hp;        
    }
}
