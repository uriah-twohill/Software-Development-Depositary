using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {
    private Animator anim;
    public GameObject gun;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();


    }
	
	// Update is called once per frame
	void Update () {
        anim.SetInteger("Transition", 1);
    }
}
