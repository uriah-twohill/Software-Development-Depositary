using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMovement : MonoBehaviour {

    public Transform camera;
   

    void FixedUpdate()
    {
        if (camera.position.x >= 10)
        {
            transform.position = new Vector3(camera.position.x + 10f, transform.position.y, transform.position.z);
        }
    }

    
}
