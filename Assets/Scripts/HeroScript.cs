using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroScript : MonoBehaviour {


    //Hero declarations
    public float jumpF = 8;
    public bool onGround = false;
    public int movementSpeed = 8;
    private Animator anim;
    public float health = 100.0f;
    public Text healthText;
    public float lives = 3;
    private bool livesCounter = true;
    public Text livesText;

    Vector2 heroPosition;
    public GameObject hero;
    public Transform hero1;
    public int heroScaleCounter;
    public GameObject camera;
    Vector2 cameraPosition;


   // public Transform camera;

    public GameObject crate;

    void Start () {
        anim = GetComponent<Animator>();
        
    }
	
     
    // Contains all movement code and user controlled animations.
	void Update ()
    {
        Time.timeScale = 1;
        // Standing still animation.
        if (Input.anyKey == false && onGround == true)
        {
            if (health >= 20)
            {
                anim.SetInteger("Transition", 1);
            }
            else
            {
                anim.SetInteger("Transition", 5);
            }
        }

        if (Input.GetKeyDown("up") && onGround == true)
        {
            Jump();
        }
        if (Input.GetKey("right") && onGround == true)
        {
            Running();
        }
        else if (Input.GetKey("left") && onGround == true)
        {
            Running();
        }
        DisplayHealth();
        if (Input.GetKeyDown("p"))
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        }
    }

        //----------------------------------------------------------------------------------------------------------------------------//
       //----------------------------------------------------------Movement----------------------------------------------------------//
      //----------------------------------------------------------------------------------------------------------------------------//

    // Jumping
    public void Jump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0f, jumpF), ForceMode2D.Impulse);
        onGround = false;
        if (health >= 20)
        {
            anim.SetInteger("Transition", 3);
        }
        else
        {
            anim.SetInteger("Transition", 7);
        }
        print("Hero has jumped");
    }
    // Running
    public void Running()
    {   
        if (Input.GetKey("right") && onGround == true)
        {
            if (heroScaleCounter == 0)
            {
                transform.localScale = new Vector3(hero1.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                heroScaleCounter = 1;
            }
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(movementSpeed, -4);
            if (health >= 20)
            {
                anim.SetInteger("Transition", 2);
            }
            else
            {
                anim.SetInteger("Transition", 6);
            }
        }
        else if (Input.GetKey("left") && onGround == true)
        {
            if (heroScaleCounter == 1)
            {
                transform.localScale = new Vector3(hero1.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                heroScaleCounter = 0;
            }
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(-movementSpeed, -4);
            if (health >= 20)
            {
                anim.SetInteger("Transition", 2);
            }
            else
            {
                anim.SetInteger("Transition", 6);
            }

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
    public void DisplayHealth()
    {
        if (health >= 0)
        {
            healthText.text = "H: " + Mathf.Round(health);
            livesText.text = "lives: " + lives;
        }
        else 
        {
            HeroDies();
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
        cameraPosition = new Vector2(camera.transform.position.x - 8, camera.transform.position.y -2.4f);
        if (lives >= 2)
        {
            Invoke("Respawn", 1.5f);
        }
        
        else
        {
            GameOver();
        }
    }

    // Respawns Hero and resets health to 100.
    public void Respawn()
    {
        anim.SetInteger("Transition", 5);
        
        hero.transform.position = cameraPosition;
        health = 100;
        if (lives >= 1  && livesCounter == true)
        {
            lives -= 1;
            livesCounter = false;
        }
        UnFreezeMovement();
    }


    // Freezing and UnFreezing movement.
    public void FreezeMovement()
    {
        onGround = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        livesCounter = true;
    }

    public void UnFreezeMovement()
    {
        onGround = true;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");        
    }
}
