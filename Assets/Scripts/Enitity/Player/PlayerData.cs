using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : Status
{
    // �÷��̾� ���� ��ų�� ����
    [SerializeField]
    private Skill[] skill_arr_;
    public Skill[] skill_arr { get => skill_arr_; }
}
