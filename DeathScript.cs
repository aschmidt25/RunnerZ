using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.lives -= 1;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
