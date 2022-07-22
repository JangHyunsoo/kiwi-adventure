using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : Status
{
    // 플레이어 고유 스킬들 저장
    [SerializeField]
    private Skill[] skill_arr_;
    public Skill[] skill_arr { get => skill_arr_; }
}
