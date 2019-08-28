using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public HeroScript heroScript;
    public GameObject bullet;
    public GameObject gun;
    Vector2 originalPosGun;
    private Animator anim;
    public SoundManager soundManager;

    public ScoreManager scoreManager;

    public float bulletSpeed = 5;

    // Use this for initialization
    void Start () {
        SoundManager.instance.BulletFire();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FixedUpdate()
    {
        //  transform.position = new Vector3(bullet.position.x -.5f, transform.position.y, transform.position.z);
        originalPosGun = new Vector2(gun.transform.position.x - 1.2f, gun.transform.position.y - .6f);
        MoveBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("bullet has collided");
        if (collision.gameObject.name == "Hero")
        {
            SoundManager.instance.BulletCollision();
            if (scoreManager.score <= 20)
            {
                heroScript.health -= 10;
                bullet.SetActive(false);
                Invoke("ResetBullet", 1);
            }
            else if (scoreManager.score >= 20)
            {
                heroScript.health -= 10;
                bullet.SetActive(false);
                Invoke("ResetBullet", 0.3f);
            }
        }
        else if (collision.gameObject.tag == "prefab01" || collision.gameObject.tag == "prefab02" || collision.gameObject.tag == "prefab03")
        {
            if (scoreManager.score <= 20)
            {

                bullet.SetActive(false);
                Invoke("ResetBullet", 1);
            }
            else if (scoreManager.score >= 20)
            {

                bullet.SetActive(false);
                Invoke("ResetBullet", 0.3f);
            }
        }
       
    }

    public void ResetBullet()
    {
        
        bullet.SetActive(true);
        bullet.transform.position = originalPosGun;
        SoundManager.instance.BulletFire();
    }

    public void MoveBullet()
    {
        if (scoreManager.score <= 20)
        {
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(-bulletSpeed, 0);
        }
        else if(scoreManager.score >= 21)
        {
            bulletSpeed = 10;
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(-bulletSpeed, 0);
        }
    }

}
