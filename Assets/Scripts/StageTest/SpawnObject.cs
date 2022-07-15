using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tiles;
    private Transform tile;
    private int tile_idx_ = 0;

    public void spawnTile()
    {
        tile = Instantiate(tiles[0], transform.position, Quaternion.identity).transform;
        tile.SetParent(transform);
    }

    public void setDoor()
    {
        tile_idx_ = 1;
    }
}