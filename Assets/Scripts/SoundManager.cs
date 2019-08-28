using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    public AudioClip jumpSound, pickupFuel, lazerCollision, die, injured, respawn, gameOver, bulletFire, bulletCollision;
    [SerializeField]
    public AudioSource soundFX;

    // Use this for initialization
    void Awake()
    {
        if (instance == null) instance = this;
    }

    // Update is called once per frame
    public void PlayJump()
    {
        soundFX.PlayOneShot(jumpSound);
    }

    public void PickupFuel()
    {
        soundFX.PlayOneShot(pickupFuel);
    }

    public void LazerCollision()
    {
        soundFX.PlayOneShot(lazerCollision);
    }

    public void PlayDie()
    {
        soundFX.PlayOneShot(die);
    }

    public void PlayInjured()
    {
        soundFX.PlayOneShot(injured);
    }

    public void PlayRespawn()
    {
        soundFX.PlayOneShot(respawn);
    }

    public void PlayGameOver()
    {
        soundFX.PlayOneShot(gameOver);
    }

    public void BulletFire()
    {
        soundFX.PlayOneShot(bulletFire);
    }
    public void BulletCollision()
    {
        soundFX.PlayOneShot(bulletCollision);
    }

}
