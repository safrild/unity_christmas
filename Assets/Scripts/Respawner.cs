using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Object for controlling the respawn of an object.
public class Respawner : MonoBehaviour
{
    //  Original position to be restored
    public Vector3 originalPosition;

    // Start is called before the first frame update
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
    }
}
