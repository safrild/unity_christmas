using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Object for controlling the respawn of an object.
public class Respawner : MonoBehaviour
{
    //  Original position to be restored
    public Vector3 originalPosition;

    // public GameObject[] tilePrefabs;
    public TileManager tm;


    void Start()
    {        
        originalPosition = this.transform.position;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<RespawnManager>().register(this);
    }

    public virtual void respawn()
    {
        this.transform.position = originalPosition;
        tm.SpawnTile(true);
        tm.SpawnGround(true);
        tm.SpawnBG(true);
              
        
    }
}
