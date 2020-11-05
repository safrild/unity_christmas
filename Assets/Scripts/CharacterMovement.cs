using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(horiz * speed, 0.0f));

        if (Input.GetButtonDown("Jump")){
            rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        }
        
    }
}
