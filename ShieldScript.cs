using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

    public static bool deleteShield = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (deleteShield)
        {
            Destroy(gameObject);
        }
	}
}
