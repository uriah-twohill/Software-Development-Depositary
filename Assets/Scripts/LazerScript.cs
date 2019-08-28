using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour {

    public HeroScript heroScript;
    public ScoreManager scoreManager;
    public SoundManager soundManager;

 

   
    
    // Use this for initialization
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (heroScript.health >= 0)
        {
            SoundManager.instance.LazerCollision();
            heroScript.health -= .2f;
        }
    }
}
