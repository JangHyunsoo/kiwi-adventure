using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private Transform[] door_tr_list_;

    private List<Transform> door_list = new List<Transform>();

    private void Start()
    {
        createRandomDoor();
    }
    
    public void createRandomDoor()
    {
        int door_count = Random.Range(2, 4);

        for(int i = 0; i < door_count; i++)
        {
            door_list.Add(Instantiate(StageManager.instance.getRandomDoorPrefab()
                , door_tr_list_[i].position, Quaternion.identity).transform);
        }
    }

    public void createBossDoor()
    {

    }
}
