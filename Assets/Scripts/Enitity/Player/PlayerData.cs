using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : Status
{
    [SerializeField]
    private Skill[] skill_list_;
    public Skill[] skill_list { get => skill_list_; }
}
