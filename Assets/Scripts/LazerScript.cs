using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour {

    public HeroScript heroScript;
    public ScoreManager scoreManager;

    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;


    void Start()
    {
        
            startPos = transform.position;
        
    }
    void Update()
    {
        if (scoreManager.score >= 20)
        {
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
    }
    // Use this for initialization
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (heroScript.health >= 0)
        {
            heroScript.health -= .2f;
        }
    }
}
