using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Class for handling multiple respawning object.
public class RespawnManager : MonoBehaviour
{
    //  List of objects to respawn
    public List<Respawner> respawnableObjects;

    //  Create a clear list of respawnables
    void Awake()
    {
        respawnableObjects = new List<Respawner>();
    }

    //  Function to be called when reset required
    public void reset()
    {
        foreach (Respawner resp in this.respawnableObjects)
        {
            resp.respawn();
        }
    }

    //  Each Respawner can register to be notified on reset.
    public void register(Respawner resp)
    {
        this.respawnableObjects.Add(resp);
    }

}
