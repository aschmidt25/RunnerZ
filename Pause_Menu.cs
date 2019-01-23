using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject CPMenu;
    public GameObject Slow;
    public GameObject Speed;
    public GameObject Shield;
    public int scoreToAdd = 0;
    public int oldTotal = 0;

    public static bool GameIsPaused;

	// Use this for initialization
	void Start ()
    {
        pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
	}

    public void Resume()
    {
        pauseMenu.SetActive(false);
        GameIsPaused = false;
        CPMenu.SetActive(false);
        Speed.SetActive(false);
        Slow.SetActive(false);
        Shield.SetActive(false);

        
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        GameIsPaused = true;

    }

    public void MainMenu()
    {
        GameIsPaused = false;
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene(1);
        
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
