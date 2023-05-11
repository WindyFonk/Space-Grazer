using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static PlayerController;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseUI;
    public AudioSource stageTheme;
    public Button resumeBtn;
    void Update()
    {
        if (!PlayerControllerStatic.playerController.isAlive)
        {
            resumeBtn.interactable = false;
            Pause();
            return;
        };

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        stageTheme.Play();
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        stageTheme.Pause();
    }

    public void Replay()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    } 
}
