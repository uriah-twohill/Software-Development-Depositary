using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour {

    public HeroScript heroScript;

    // Use this for initialization
    private void OnTriggerStay2D(Collider2D collision)
    {
        heroScript.health -= 0.5f;
    }
}
