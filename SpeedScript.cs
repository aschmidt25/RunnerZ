using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedScript : MonoBehaviour {

    public static bool deleteSpeed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (deleteSpeed)
        {
            Destroy(gameObject);
        }
	}
}
