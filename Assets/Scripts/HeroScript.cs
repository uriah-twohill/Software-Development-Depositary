using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroScript : MonoBehaviour {


    //Hero declarations
    public float jumpForce = 7.0f;
    private bool onGround = false;
    public int movementSpeedRight = 4;
    public int movementSpeedLeft = 4;
    private Animator anim;
    public float health = 100;
    public Text healthText;

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

        if (Input.GetKey("right") && onGround == true)
        {
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(movementSpeedRight, 0);
            anim.SetTrigger("RunRight");
        }

        if (Input.GetKey("left") && onGround == true)
        {
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(-movementSpeedLeft, 0);
            anim.SetTrigger("RunLeft");
        }
        DisplayHealth();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        print("Hero has touched ground");
    }

    public void DisplayHealth()
    {
        healthText.text = "H: " + health;
    }


}
