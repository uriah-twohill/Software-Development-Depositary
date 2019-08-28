using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform hero;

    void FixedUpdate()
    {
        if (hero.position.x >= 10)
        {
            transform.position = new Vector3(hero.position.x, transform.position.y, transform.position.z);
        }
    }
}
    

