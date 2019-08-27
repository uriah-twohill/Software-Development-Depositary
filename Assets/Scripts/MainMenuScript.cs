using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
        if (Input.GetKeyDown("s"))
        {
            SceneManager.LoadScene("10thPlanet");
        }
        else if (Input.GetKeyDown("h"))
        {
            SceneManager.LoadScene("Help");
        }
    }
}
