using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Specialized class for respawning enemy
public class EnemyRespawner : Respawner
{
    public int original_life;

    void Start()
    {
        originalPosition = this.transform.position;
        original_life = this.GetComponent<EnemyDestroy>().life;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<RespawnManager>().register((Respawner)this);
    }

    public override void respawn()
    {
        this.transform.position = originalPosition;
        this.GetComponent<EnemyDestroy>().life = original_life;
        gameObject.SetActive(true);
    }
}
