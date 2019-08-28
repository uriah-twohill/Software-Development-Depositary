using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{

    public GameObject currentPrefab;
    public GameObject nextPrefab;
    private GameObject[] objectList;
    public float incrementX = 20;
    public GameObject invisibleWall1;
    public GameObject invisibleWall2;
    public GameObject camera;
    public float cameraLimit;
    public GameObject fuelCan;
    public GameObject laser;
    public GameObject crate;
    public GameObject gun;




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
        if (collision.gameObject.name == "Hero")
        {
            Debug.Log("Touched prefab trigger.");
            Vector3 temp = currentPrefab.transform.position;
            temp.x = temp.x + 25.7f;
            nextPrefab.transform.position = temp;
            invisibleWall1.SetActive(false);
            invisibleWall2.SetActive(true);

            Random random = new Random();

            int choice = Random.Range(0, 7);
            if (choice == 0)
            {
                fuelCan.SetActive(true); laser.SetActive(true); crate.SetActive(true); gun.SetActive(false);
            }
            else if (choice == 1)
            {
                fuelCan.SetActive(false); laser.SetActive(false); gun.SetActive(true); crate.SetActive(true);
            }
            else if (choice == 2)
            {
                crate.SetActive(true); gun.SetActive(true); fuelCan.SetActive(true); laser.SetActive(true);
            }
            else if (choice == 3)
            {
                crate.SetActive(false); gun.SetActive(true); fuelCan.SetActive(false); laser.SetActive(true);
            }
            else if (choice == 4)
            {
                crate.SetActive(false); gun.SetActive(false); fuelCan.SetActive(false); laser.SetActive(true);
            }
            else if (choice == 5)
            {
                crate.SetActive(true); gun.SetActive(false); fuelCan.SetActive(true); laser.SetActive(true);
            }
            else if (choice == 6)
            {
                crate.SetActive(true); gun.SetActive(true); fuelCan.SetActive(true); laser.SetActive(false);
            }
            else if (choice == 7)
            {
                crate.SetActive(false); gun.SetActive(false); fuelCan.SetActive(false); laser.SetActive(false);
            }
        }
        //  invisibleWall.SetActive(true);


    }
    /*     objectList = GameObject.FindGameObjectsWithTag("prefab01");
         // Array number needs to be randomized.
         for(int i = 0; i < objectList.Length; i++)
         objectList[i].SetActive(false);

         objectList[0].SetActive(true);*/
}
    

