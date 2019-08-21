using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{



    public Text scoreText;
    private float score;
    private float startTime;
    //public Text livesText;
    //public float lives = 3;
    public float jumpCounter;

    public GameObject hero;

    HeroScript heroScript;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreIncrease();
      //  DisplayLives();
        
    }
    public void IncreaseOnJump()
    {
        jumpCounter += 2;
    }

    public void ScoreIncrease()
    {
        score = (int)(Time.time - startTime);
        scoreText.text = "S: " + score;
    }

   /* public void DisplayLives()
    {
        livesText.text = "lives: " + lives;
        
    }
    */
    

}
