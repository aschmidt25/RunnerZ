using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Main_Menu : MonoBehaviour
{

    public static int totalScore = 0;
    public Text MenuScore;

    void Update ()
    {
        DisplayScore();
    }
    
    public void DisplayScore()
    {
        //put score on screen using totalScore variable
        MenuScore.text = " Current Supplies: " + totalScore.ToString();
    }

	public void PlayGame ()
    {
        Pause_Menu.GameIsPaused = false;
        SceneManager.LoadScene(2);
       
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits ()
    {
        SceneManager.LoadScene(5);
    }
		
	
}
