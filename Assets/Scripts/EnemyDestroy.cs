using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public int life = 3;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CandyCane")
        {
            col.gameObject.SetActive(false);
            this.life--;
            if (this.life <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }

    }

}
