using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public float score;
    
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
        score = (int)(Time.timeSinceLevelLoad);
        score = score + jumpCounter;
        scoreText.text = "S: " + score;
    }
}
