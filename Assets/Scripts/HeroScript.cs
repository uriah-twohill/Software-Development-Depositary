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
    public float lives = 3;
    public Text livesText;

    Vector2 originalPosH;
    public GameObject hero;
    public Transform hero1;
    public int heroScaleCounter;

    public Transform camera;

    



    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey == false && onGround == true)
        {
            anim.SetInteger("Transition", 1);
            DisplayLives();
        }

        if (Input.GetKeyDown("up"))
        {
            if (onGround == true)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                onGround = false;
                anim.SetInteger("Transition", 3);
                print("Hero has jumped");
            }
        }

        if (Input.GetKey("right") && onGround == true)
        {
            if (Input.GetKey("right") && onGround == true && heroScaleCounter == 0)
            {
                transform.localScale = new Vector3(hero1.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                heroScaleCounter = 1;
            }
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(movementSpeedRight, 0);
            anim.SetInteger("Transition", 2);
        }

        if (Input.GetKey("left") && onGround == true)
        {
            if (Input.GetKey("left") && onGround == true && heroScaleCounter == 1)
            {
                transform.localScale = new Vector3(hero1.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                heroScaleCounter = 0;
            }
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(-movementSpeedLeft, 0);
            anim.SetInteger("Transition", 2);
        }
        DisplayHealth();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        print("Hero has touched ground");
    }

    public void DisplayLives()
    {
        livesText.text = "lives: " + lives;
    }

    public void DisplayHealth()
    {
        if (health >= 0)
        {
            healthText.text = "H: " + health;
        }
        else
        {
            anim.SetInteger("Transition", 4);
            Invoke("Respawn", 3);
            

            if (lives >= 1)
            {
                lives -= 1;
            }
           
            
           // anim.SetInteger("Transition", 5);
            
        }
    }

   public void Respawn()
    {
        health = 100;
        transform.position = new Vector3(camera.position.x -5, transform.position.y, transform.position.z);
        anim.SetInteger("Transition", 5);
        Invoke("anim.SetInteger('Transition'", 2);
    }


}
