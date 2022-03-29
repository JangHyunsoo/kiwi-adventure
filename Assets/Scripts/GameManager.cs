using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        initDataBase();
        initManager();
    }
    
    void Update()
    {
        
    }

    private void initManager()
    {
        StageManager.instance.init();
        PlayerManager.instance.init();
        SkillInventory.instance.init();
    }


    private void initDataBase()
    {
        SkillDataBase.instance.init();
    }
}
