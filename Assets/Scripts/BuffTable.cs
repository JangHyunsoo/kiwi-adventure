using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTable : MonoBehaviour
{
    private Entity entity_;
    private List<Buff> buff_list_ = new List<Buff>();
    
    public void Awake()
    {
        init();
    }

    public void Update()
    {
        if(buff_list_.Count > 0)
        {
            for (int i = 0; i < buff_list_.Count; i++)
            {
                if(buff_list_[i].activate(entity_))
                {
                    buff_list_.Remove(buff_list_[i--]);
                }
            } 
        }
    }

    public void init()
    {
        entity_ = GetComponent<Entity>();
    }

    public void addBuff(Buff _buff)
    {
        foreach (var buff in buff_list_)
        {
            if(buff.name == _buff.name)
            {
                buff.increaseStack(_buff);
                return;
            }
        }
        buff_list_.Add(_buff);
    }

    public void deleteBuff()
    {

    }




}
