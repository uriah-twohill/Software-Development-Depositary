using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroScript : MonoBehaviour {


    //Hero declarations
    public float jumpForce = 10.0f;
    private bool onGround = false;
    public int movementSpeed = 10;
    private Animator anim;
    public float health = 100;
    public Text healthText;
    public float lives = 3;
    public Text livesText;

    Vector2 heroPosition;
    public GameObject hero;
    public Transform hero1;
    public int heroScaleCounter;

    public Transform camera;

    




    void Start () {
        anim = GetComponent<Animator>();
    }
	
     
    // Contains all movement code and user controlled animations.
	void Update ()
    {
        // Standing still animation.
        if (Input.anyKey == false && onGround == true)
        {
            anim.SetInteger("Transition", 1);
        }

        Jump();
        Running();
        DisplayHealthAndLives();
     }

        //----------------------------------------------------------------------------------------------------------------------------//
       //----------------------------------------------------------Movement----------------------------------------------------------//
      //----------------------------------------------------------------------------------------------------------------------------//

    // Jumping
    public void Jump()
    {
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
    }
    // Running
    public void Running()
    {
        if (Input.GetKey("right") && onGround == true)
        {
            if (Input.GetKey("right") && onGround == true && heroScaleCounter == 0)
            {
                transform.localScale = new Vector3(hero1.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                heroScaleCounter = 1;
            }
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(movementSpeed, 0);
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
            rb1.velocity = new Vector2(-movementSpeed, 0);
            anim.SetInteger("Transition", 2);
        }
    }

        //------------------------------------------------------------------------------------------------------------------------------//
       //------------------------------------------------------Passive Mechanics-------------------------------------------------------//
      //------------------------------------------------------------------------------------------------------------------------------//

    // Ground detection.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        print("Hero has touched ground");
    }

    // Display Health and Lives function.
    public void DisplayHealthAndLives()
    {
        if (health >= 0)
        {
            healthText.text = "H: " + health;
            livesText.text = "lives: " + lives;
        }
        else
        {
            HeroDies();
            ReduceLife();     
        }
    }

        //------------------------------------------------------------------------------------------------------------------------------//
       //-----------------------------------------------------------Death--------------------------------------------------------------//
      //------------------------------------------------------------------------------------------------------------------------------//

    // The Hero Dies.
    public void HeroDies()
    {
        anim.SetInteger("Transition", 4);
        FreezeMovement();
        
     //   if (lives >= 1)
     //   {
            Invoke("Respawn", 1.5f);
    //    }
        /*
        else ()
        {
            Game over transition to be coded.
        }
        */
    }

    // Reduces life
    public void ReduceLife()
    {
        if (lives >= 1)
        {
            lives -= 1;
        }
    }

    // Respawns Hero and resets health to 100.
    public void Respawn()
    {
        anim.SetInteger("Transition", 5);
        transform.position = new Vector3(camera.position.x - 10, transform.position.y, transform.position.z);
        health = 100;
        UnFreezeMovement();
    }


    // Freezing and UnFreezing movement.
    public void FreezeMovement()
    {
        onGround = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    public void UnFreezeMovement()
    {
        onGround = true;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    }
}
