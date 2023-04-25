using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoundBullet : MonoBehaviour
{
    private Transform player;
    private Vector3 target;
    private Rigidbody2D rb;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        target = player.transform.position;

        Vector3 direction = target - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rotat = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotat + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bound") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
