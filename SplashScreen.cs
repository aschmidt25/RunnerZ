using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(LoadScene());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(1);
    }
}
