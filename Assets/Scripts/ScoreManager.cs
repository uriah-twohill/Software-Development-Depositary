using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    private float score;
    private float startTime;
    
    public float jumpCounter;


    void Start()
    {

    }

    void Update()
    {
        ScoreIncrease();
       
    }

    public void IncreaseOnJump()
    {
        jumpCounter += 2;
    }

    public void ScoreIncrease()
    {
        score = (int)(Time.time - startTime);
        score = score + jumpCounter;
        scoreText.text = "S: " + score;
    }
}
