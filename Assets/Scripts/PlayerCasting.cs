using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    private bool _isCasting = false;
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        fireSkill();
    }
    private void castSkill()    // 스페이스바
    {

    }
    private void fireSkill()    // 클릭
    {
        if (Input.GetMouseButtonDown(0))
        {
            _player.current_skill.activate(transform.position);
        }
    }
         
}
