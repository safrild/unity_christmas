using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Rigidbody2D candyCaneProto = null;
    public float speed = 20.0f;
     public Transform firePoint;
     public int itemPoolSize = 10;
     public List<Rigidbody2D> itemPool;

    // Start is called before the first frame update
    void Start()
    {
        itemPool = new List<Rigidbody2D>();
        for (int i = 0; i< itemPoolSize; i++)
        {
            Rigidbody2D candyCaneClone = Instantiate(candyCaneProto, firePoint.position, candyCaneProto.transform.rotation);
            candyCaneClone.gameObject.SetActive(false);
            itemPool.Add(candyCaneClone);

        }
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
        Rigidbody2D candyCaneClone = getItemFromPool();
        candyCaneClone.transform.position = firePoint.position;

        candyCaneClone.gameObject.SetActive(true);

        float direction = CharacterMovement.facingRight ? +1 : -1;

        Vector3 force = transform.right * speed * direction;
        candyCaneClone.velocity = force;

    }

    private Rigidbody2D getItemFromPool(){
        foreach (Rigidbody2D item in itemPool)
        {
            if (!item.gameObject.activeSelf) 
            {
                return item;
            }
            
        }
        return null;
    }
}
