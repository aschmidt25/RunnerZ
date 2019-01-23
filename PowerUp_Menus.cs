using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Menus : MonoBehaviour
{
    public bool TutIsActive = false;
    public GameObject slow;
    public GameObject speed;
    public GameObject shield;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
     
	}

    public void CloseWindow ()
    {
        TutIsActive = false;
        slow.SetActive(false);
        speed.SetActive(false);
        shield.SetActive(false);
    }
}
