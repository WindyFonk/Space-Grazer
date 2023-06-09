using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class Boss1: MonoBehaviour
{
    private float timeBetweenShot;
    public GameObject BulletPrefab,BulletFollowPrefab,DeathAnimation,HealthOrb;
    public float startTimeBetweenShot;

    public Animator animator;

    public int phase;

    private float timer;
    public float health = 200;


    [SerializeField] float leftbound;
    [SerializeField] float rightbound;
    void Start()
    {
        phase = 1;
        timeBetweenShot = startTimeBetweenShot;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PhaseManager();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 1;
            PlayerControllerStatic.playerController.setScores(2);
        }
    }

    private void PhaseManager()
    {

        if (health <= 200)
        {
            phase =2;
        }

        if (health <= 120)
        {
            phase = 3;
        }
        if (health <= 0)
        {
            phase = 4;
        }

        switch(phase)
        {
            case 1:
                FirstPhase();
                break;

            case 2:
                SecondPhase();
                break;

            case 3:
                ThirdPhase();
                break;
            case 4:
                EndLevel();
                break;
        }
    }

    private void shoot()
    {
        if (timeBetweenShot <= 0)
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            timeBetweenShot = startTimeBetweenShot;
        }
        else
        {
            timeBetweenShot -= Time.deltaTime;
        }
    }

    IEnumerator shootbounce()
    {

        yield return new WaitForSeconds(2);

        if (timeBetweenShot <= 0)
        {
            Instantiate(BulletFollowPrefab, transform.position, Quaternion.identity);
            timeBetweenShot = startTimeBetweenShot;
        }
        else
        {
            timeBetweenShot -= Time.deltaTime;
        }

    }

    private void FirstPhase()
    {
        shoot();
    }

    private void SecondPhase()
    {
        shoot();
        animator.SetTrigger("Second");
    }

    private void ThirdPhase()
    {
        animator.SetTrigger("Third");
        StartCoroutine(shootbounce());
    }

    private void EndLevel()
    {
        animator.SetTrigger("Death");
        Invoke("Death", 2.5f);
    }

    private void Death()
    {
        Destroy(gameObject);
        Instantiate(DeathAnimation, transform.position, Quaternion.identity);
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject bullet in bullets)
            GameObject.Destroy(bullet);
    }

}
