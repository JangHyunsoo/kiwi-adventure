using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static StageManager _instance;
    public static StageManager instance
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
    void Update()
    {
        
    }
}
