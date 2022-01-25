using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillBook : Item
{
    private List<int> skill_code_list_;
    private SkillBookRarity skillbook_rarity_;

    public override void activate()
    {
        // open skillbook seleting ui
    }

}
