using DanmakU;
using DanmakU.Fireables;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject hitbox;
    private float speed=5;
    [SerializeField] Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator animator;

    //shoot
    public GameObject BulletPrefab;
    private Vector3 offset; 
    private float timeBetweenShot;
    public float startTimeBetweenShot =0.3f;

    //health
    public int maxHealth = 4 ;
    public int currentHealth;
    public HealthBar healthBar;

    //audio
    public AudioSource shoot;

    //score
    private static int score;
    public TextMeshProUGUI scoretext;

    public void setScores(int number)
    {
        score += number;
        scoretext.text = "" + score;
    }

    public static class PlayerControllerStatic
    {
        public static PlayerController playerController;
    }


    private void Start()
    {
        PlayerControllerStatic.playerController = this;
        setScores(0);

        animator=GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        GetComponent<DanmakuCollider>().OnDanmakuCollision += OnDanmakuCollision;
        timeBetweenShot = startTimeBetweenShot;
        offset = new Vector3(0, 0.5f, 0);
    }

    void OnDanmakuCollision(DanmakuCollisionList collisionList)
    {
        foreach (DanmakuCollision collision in collisionList)
        {
            Debug.Log(collision.ToString());
            takeDamage(1);
        }
        //Destroy(gameObject);

    }
    void FixedUpdate()
    {
        Control();
    }

    

    private void Control()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(horizontal, vertical).normalized;
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

        //move
        if (Input.GetKey(KeyCode.LeftShift))
        {
            hitbox.SetActive(true);
            speed = 4;
        }
        else
        {
            hitbox.SetActive(false);
            speed = 7;
        }

        //shoot
        if (Input.GetKey(KeyCode.Z))
        {
            if (timeBetweenShot <= 0)
            {
                Instantiate(BulletPrefab, transform.position + offset, Quaternion.identity);
                timeBetweenShot = startTimeBetweenShot;
                shoot.Play();
            }
            else
            {
                timeBetweenShot -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            takeDamage(1);
        }
    }

    private void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        animator.SetTrigger("Hit");
    }

    
}
