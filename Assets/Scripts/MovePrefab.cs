using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{

    public GameObject currentPrefab;
    public GameObject nextPrefab;
    private GameObject[] objectList;
    public float incrementX = 20;
    public GameObject invisibleWall;
    public GameObject camera;
    public float cameraLimit;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched prefab trigger.");
        Vector3 temp = currentPrefab.transform.position;
        temp.x = temp.x + 25.7f;
        nextPrefab.transform.position = temp;

      //  invisibleWall.SetActive(true);


    }
    /*     objectList = GameObject.FindGameObjectsWithTag("prefab01");
         // Array number needs to be randomized.
         for(int i = 0; i < objectList.Length; i++)
         objectList[i].SetActive(false);

         objectList[0].SetActive(true);*/
}
    

