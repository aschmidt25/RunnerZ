using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationRate = 100.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.down, rotationRate * Time.deltaTime);
	}
}
