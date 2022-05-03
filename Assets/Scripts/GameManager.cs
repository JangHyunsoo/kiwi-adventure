using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null) { return null; }
            else { return _instance; }
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool is_game_over = true;

    void Start()
    {
        initDataBase();
        initManager();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("test");
            is_game_over = false;
            Application.Quit();
        }
    }

    private void initManager()
    {
        StageManager.instance.init();
        PlayerManager.instance.init();
        SkillInventory.instance.init();
        ItemInventory.instance.init();
    }


    private void initDataBase()
    {
        SkillDataBase.instance.init();
        ItemDataBase.instance.init();
    }
}
