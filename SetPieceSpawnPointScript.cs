using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPieceSpawnPointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
