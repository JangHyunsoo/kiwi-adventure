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

    [SerializeField]
    private GameObject[] exit_door_prefab_list_;

    [SerializeField]
    private Transform[] enter_door_tr_list_;

    public GameObject getDoorPrefab(int _id)
    {
        return exit_door_prefab_list_[_id];
    }
    public GameObject getRandomDoorPrefab()
    {
        return exit_door_prefab_list_[Random.Range(0, exit_door_prefab_list_.Length)];
    }
    public Vector2 getEnterDoorPosition(int _id)
    {
        return enter_door_tr_list_[_id].position;
    }
}
