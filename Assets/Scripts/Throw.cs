using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Rigidbody2D candyCaneProto = null;
    public float speed = 20.0f;
     public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            throwCandyCane();
        }

    }

    void throwCandyCane() 
    {
        Rigidbody2D candyCaneClone = Instantiate(candyCaneProto, firePoint.position, candyCaneProto.transform.rotation);

        float direction = CharacterMovement.facingRight ? +1 : -1;

        Vector3 force = transform.right * speed * direction;
        candyCaneClone.velocity = force;

    }
}
