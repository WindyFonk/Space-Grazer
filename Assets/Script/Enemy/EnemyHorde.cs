using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorde : MonoBehaviour
{
    private float timeBetweenSpawn;
    public GameObject Enemy;
    public float startTimeBetweenSpawn;
    public float timeTilEnd;

    void Start()
    {
        timeBetweenSpawn = startTimeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawn <= 0)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }

        Destroy(gameObject,timeTilEnd);
    }
}
