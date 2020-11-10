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
        //  On Start store original position
        originalPosition = this.transform.position;
        //  And notify RespawnManager about self.
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<RespawnManager>().register(this);
    }

    //  If respawn, restore original position.
    public virtual void respawn()
    {
        this.transform.position = originalPosition;
        tm.SpawnTile(true);
        tm.SpawnGround(true);
        tm.SpawnBG(true);
        /*for (int i = 0; i < tm.amountOfTilesOnScreen; i++)
        {
            tm.SpawnTile(true);
        }
        for (int i = 0; i < tm.amountOfGroundOnScreen; i++)
        {
            tm.SpawnGround();
        }*/        
        
    }
}
