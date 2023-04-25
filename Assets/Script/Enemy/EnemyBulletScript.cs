using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private Transform player;
    private Vector3 target;
    private Rigidbody2D rb;
    public float speed=2;
    public int bouncetime;

    public bool BounceFollow;
    private bool colli;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb= GetComponent<Rigidbody2D>();

        target = player.transform.position;
        AimAtPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bound") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

        }


        if (!BounceFollow)
        {
            return;
        }

            if (collision.gameObject.CompareTag("LevelBound"))
            {
                AimAtPlayer();
                Destroy(gameObject, 10);
            }
        
    }

    private void AimAtPlayer()
    {
        Vector3 direction = target - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rotat = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotat + 90);      
    }


}
