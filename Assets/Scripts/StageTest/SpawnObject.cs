using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tiles;

    private Transform tile;

    void Start()
    {
        tile = Instantiate(tiles[0], transform.position, Quaternion.identity).transform;
        tile.SetParent(transform);
    }
}