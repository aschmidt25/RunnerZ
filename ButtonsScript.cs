using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour {

    public Button Save;

	// Use this for initialization
	void Start () {
        Save.onClick.AddListener(SaveProgress);
	}

    void SaveProgress()
    {
        Main_Menu.totalScore += Player.score;
        Debug.Log(Main_Menu.totalScore);
        SceneManager.LoadScene(1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
