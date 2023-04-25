using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtnScript : MonoBehaviour
{
    public GameObject spaceship;
    private Animator animator;
    void Start()
    {
        animator =spaceship.GetComponent<Animator>();
        Time.timeScale= 1.0f;
    }

    public void Play()
    {
        StartCoroutine(StartGame());
        animator.SetTrigger("Leave");
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
