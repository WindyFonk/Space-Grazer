using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class NormalEnemy : MonoBehaviour
{
    private float timeBetweenShot;
    public GameObject BulletPrefab,DeathAnimation;
    private GameObject deathanim;
    public float startTimeBetweenShot;

    public Animator animator;
    private float timer;
    [SerializeField] float health;
    public bool shoot;

    public AudioSource shootsfx;
    void Start()
    {
        timeBetweenShot = startTimeBetweenShot;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
      
        if (health < 1)
        {
            Destroy(gameObject);            
            Instantiate(DeathAnimation, transform.position, Quaternion.identity);
            PlayerControllerStatic.playerController.setScores(5);
        }
        Destroy(gameObject,20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 1;
            PlayerControllerStatic.playerController.setScores(1);
        }

        if (collision.gameObject.CompareTag("Bound"))
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        if (shoot)
        {
            if (timeBetweenShot <= 0)
            {
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                timeBetweenShot = startTimeBetweenShot;
                shootsfx.Play();
            }
            else
            {
                timeBetweenShot -= Time.deltaTime;
            }
        }
    }

}
