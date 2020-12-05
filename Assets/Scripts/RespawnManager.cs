using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RespawnManager : MonoBehaviour
{
    public List<Respawner> respawnableObjects;

    void Awake()
    {
        respawnableObjects = new List<Respawner>();
    }


    public void reset()
    {
        foreach (Respawner resp in this.respawnableObjects)
        {
            resp.respawn();
        }
    }

 
    public void register(Respawner resp)
    {
        this.respawnableObjects.Add(resp);
    }

}
