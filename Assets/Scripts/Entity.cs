using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private int _max_hp;
    private int _current_hp;

    public int max_hp       { get => _max_hp; set => _max_hp = value; }
    public int current_hp   { get => _current_hp; set => _current_hp = value; }
}
