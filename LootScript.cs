using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    public float rotationRate = 100.0f;

	// Use this for initialization
	void Start ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(Vector3.up, rotationRate * Time.deltaTime);
	}
}
