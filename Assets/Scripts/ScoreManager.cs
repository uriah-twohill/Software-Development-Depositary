using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

   

    public Text scoreText;
    private float score;
    private float startTime;
    public Text livesText;
    private float lives = 3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ScoreIncrease();
         DisplayLives();
    }

    public void ScoreIncrease()
    {
        score = (int)(Time.time - startTime);
        scoreText.text = "Score: " + score;
    }

    public void DisplayLives()
    {
        livesText.text = "lives: " + lives;
    }

    public void IncreaseOnJump()
    {
        score += 2;
        Debug.Log("increadfka");
    }
}
