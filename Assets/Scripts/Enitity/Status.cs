using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : ScriptableObject
{
    [SerializeField]
    private Sprite obj_sprite_;
    public Sprite obj_sprite { get => obj_sprite_; }
    [SerializeField]
    private string obj_name_;
    public string obj_name { get => obj_name_; }
    [SerializeField]
    private int level_;
    public int level { get => level_; set => level = value; }
    [SerializeField]
    private int max_hp_;
    public int max_hp { get => max_hp_; set => max_hp_ = value; }
    [SerializeField]
    private float speed_;
    public float speed { get => speed_; set => speed = value; }
}
