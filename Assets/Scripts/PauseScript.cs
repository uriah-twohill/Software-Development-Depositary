using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
        if (Input.GetKeyDown("r"))
        {
            SceneManager.UnloadSceneAsync("Pause");
        }
        else if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
