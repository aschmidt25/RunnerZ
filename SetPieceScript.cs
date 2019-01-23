using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPieceScript : MonoBehaviour {

    private GameObject player;
    public float destroyDistance = 100;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.z - transform.position.z > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
