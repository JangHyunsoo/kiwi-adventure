using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkNode
{
    private Perk perk_;
    public Perk perk { get => perk_; }

    public PerkNode(Perk _perk)
    {
        perk_ = _perk;
    }

    private List<PerkNode> parents_ = new List<PerkNode>();
    private List<PerkNode> children_ = new List<PerkNode>();

    public void setChilren(params PerkNode[] _perk_node)
    {
        foreach (var node in _perk_node)
        {
            children_.Add(node);
        }
    }
    
}

public class PerkTree 
{
    private Dictionary<string, PerkNode> perk_dic_;

    public void init()
    {
        PerkNode fire_base_perk = new PerkNode(new FireBasePerk("fire base perk", 5, 0.25f));

        perk_dic_["Fire Tree"] = fire_base_perk;
    }
}
