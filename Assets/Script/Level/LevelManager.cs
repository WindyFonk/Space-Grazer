using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class LevelManager : MonoBehaviour
{
    public double Seconds;
    public AudioSource level;
    public Transform spawnPos1,spawnPos2,spawnMiddle,spawnLeft,spawnRight;
    public GameObject Enemyhorde1,Enemyhordeside, Enemyhordewontshoot, EnemyhordewontshootLeft,
        boss1,textwin,panelwin;

    private Animator animatorpanelWin;

    public Boss1 boss1script;
    // Start is called before the first frame update
    void Start()
    {
        level.Play();
        EnemySpawn();
        animatorpanelWin = panelwin.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("LoadStage2", 60);
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

    private void LoadStage2()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1)
        {
            StartCoroutine(loadWin());
            StartCoroutine(loadScene2());
        }
    }

    IEnumerator loadScene2()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(2);
    }

    IEnumerator loadWin()
    {
        yield return new WaitForSeconds(2);
        animatorpanelWin.SetTrigger("Win");
        yield return new WaitForSeconds(2);
        textwin.SetActive(true);
    }



}
