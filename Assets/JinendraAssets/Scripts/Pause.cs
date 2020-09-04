using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false ;
    public GameObject pauseMenuUI;

    public Text timerText;
    public float startTime;

    void Start()
    {
        startTime = Time.time;
	}
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("F2");

        timerText.text = minutes + ":" + seconds;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                Resume();
			}
            else
            {
                m_Pause();
			}
		}
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
	}

    void m_Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
	}

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
	}

    public void QuitGame()
    {
        Debug.Log("Ending!!!");
        Application.Quit();
	}

}
