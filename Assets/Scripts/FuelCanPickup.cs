using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCanPickup : MonoBehaviour {

    public HeroScript heroScript;
    public GameObject gameObject;
    public SoundManager soundManager;

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (heroScript.health > 0 && heroScript.health <= 90)
        {
            heroScript.health += 10;
            gameObject.SetActive(false);
            SoundManager.instance.PickupFuel();
        }
        else if (heroScript.health > 90 && heroScript.health < 100)
        {
            heroScript.health = 100;
            gameObject.SetActive(false);
        }
        
    }
}
