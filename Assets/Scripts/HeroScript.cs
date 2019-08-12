using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour {

    public float jumpForce = 7.0f;
    private bool onGround = false;
    public int movementSpeed = 4;
    private Animator anim;
 
    Vector2 originalPosH;
    public GameObject hero;
    


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up"))
        {
            if (onGround == true)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                onGround = false;
                anim.SetTrigger("Jump");
                print("Hero has jumped");
            }
        }
        if (onGround == true)
        {
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(movementSpeed, 0);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        print("Hero has touched ground");
    }
}
