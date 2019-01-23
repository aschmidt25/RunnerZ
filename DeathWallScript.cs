using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWallScript : MonoBehaviour {

    public GameObject player;
    private Vector3 playerPos;
    public float forwardSpeed = 14.5f;
    public float speedMax = 17.75f;
    public float speedIncrease = .25f;
    public float speedIncreaseDistance = 200f;
    private float multiplier = 1;
    public bool isDead = false;
    public float horizontalSpeed = 10f;
	
        // Use this for initialization
	void Start () {

	}


    // Update is called once per frame
    void Update () {
        if (forwardSpeed != speedMax)
        {
            if (transform.position.z - speedIncreaseDistance * multiplier >= 0)
            {
                forwardSpeed += speedIncrease;
                multiplier += 1;
            }


        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
        }

        playerPos = player.transform.position;

        if (transform.position.z > player.transform.position.z)
        {
            isDead = true;
        }

        if (!isDead)
        {
            transform.position += transform.forward * forwardSpeed * Time.deltaTime;
        }

        //death code here
        else
        {
            SceneManager.LoadScene(3);
        }
	}
}
