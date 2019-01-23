using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour {

    public static bool deleteTime = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (deleteTime)
        {
            Destroy(gameObject);
        }
	}
}
