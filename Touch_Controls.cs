using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Controls : MonoBehaviour {


    public int horizontalSpeed = 10;
    private Rigidbody playerBody;
    public GameObject player;


    // Use this for initialization
    void Start ()
    {

        playerBody = player.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        int count = 0;
        while (count < Input.touchCount)
        {
            if (Input.GetTouch(count).position.x > Screen.width / 2)
            {
                //move right
                RunPlayer(1.0f);
            }
            if (Input.GetTouch(count).position.x < Screen.width / 2)
            {
                //move left
                RunPlayer(-1.0f);
            }
            ++count;
        }
    }

    void RunPlayer(float horizontalInput)
    {
        playerBody.AddForce(new Vector3(horizontalInput * horizontalSpeed * Time.deltaTime, 0));
    }
}
