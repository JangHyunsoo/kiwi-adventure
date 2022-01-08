using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private List<Skill> _skill_list;
    private Skill _current_skill;
    public Skill current_skill { get => _current_skill; }

    private void Awake()
    {
        init();
    }
    private void init()
    {
        this.max_hp = 10;
        this.current_hp = this.max_hp;
        this._current_skill = SkillDataBase.instance.getSkill(0);
    }

    public Skill getCurrentSkill()
    {
        return _current_skill;
    }
}
