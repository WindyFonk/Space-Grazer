using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class LevelManager : MonoBehaviour
{
    public double Seconds;
    public AudioSource level;
    public Transform spawnPos1,spawnPos2,spawnMiddle,spawnLeft,spawnRight;
    public GameObject Enemyhorde1,Enemyhordeside, Enemyhordewontshoot, EnemyhordewontshootLeft,
        boss1, danmaku1;

    public Boss1 boss1script;
    // Start is called before the first frame update
    void Start()
    {
        level.Play();
        EnemySpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss1script.health < 100)
        {
            danmaku1.SetActive(false);
        }
    }

    private void EnemySpawn()
    {
        Invoke("SpawnEnemyRight", 3);
        Invoke("SpawnEnemyLeft", 3.5f);
        Invoke("SpawnHordeLeftSide", 12);
        Invoke("SpawnHordeRightSide", 15);
        Invoke("SpawnHordeLeftSide", 19);
        Invoke("SpawnHordeRightSide", 19);
        Invoke("SpawnHordeWontShoot", 26);
        Invoke("SpawnEnemyRight", 28);
        Invoke("SpawnEnemyLeft", 30);
        Invoke("SpawnHordeWontShootLeft", 38);
        Invoke("SpawnEnemyRight", 40);
        Invoke("SpawnEnemyLeft", 42);
        Invoke("SpawnBoss1", 49);
        Invoke("SpawnBoss1Danmaku", 51);
    }

    private void SpawnEnemyRight()
    {
        Instantiate(Enemyhorde1,spawnPos2.position,Quaternion.identity);
    }

    private void SpawnEnemyLeft()
    {
        Instantiate(Enemyhorde1, spawnPos1.position, Quaternion.identity);
    }

    private void SpawnHordeLeftSide()
    {
        Instantiate(Enemyhordeside);
    }
    

    private void SpawnHordeRightSide()
    {
        GameObject Enemyhordersright = Enemyhordeside;
        Vector2 scale = Enemyhordersright.transform.localScale;
        scale.x *= 1;
        Enemyhordersright.transform.localScale = scale;
        Enemyhordeside.transform.eulerAngles = new Vector3(
        Enemyhordeside.transform.eulerAngles.x +180,
        Enemyhordeside.transform.eulerAngles.y,
        Enemyhordeside.transform.eulerAngles.z +180);
        Instantiate(Enemyhordersright);
    }

    private void SpawnHordeWontShoot()
    {
        Instantiate(Enemyhordewontshoot);
    }

    private void SpawnHordeWontShootLeft()
    {
        Instantiate(EnemyhordewontshootLeft);

    }

    private void SpawnBoss1()
    {
        boss1.SetActive(true);

    }

    private void SpawnBoss1Danmaku()
    {
        danmaku1.SetActive(true);

    }




}
