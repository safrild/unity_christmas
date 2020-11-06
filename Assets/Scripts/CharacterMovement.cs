using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    public static bool facingRight = true;


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(horiz * speed, 0.0f));

        if (facingRight && horiz < 0)
        {
            flip();
        }
        else if (!facingRight && horiz > 0)
        {
            flip();
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        }

    }

    private void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag=="Enemy") {
				GameObject.FindGameObjectWithTag("GameManager").GetComponent<RespawnManager>().reset();
            }
        }
}
