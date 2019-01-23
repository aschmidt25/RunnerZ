using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public Transform PlayerT;
    public int chaseDistance = 60;
    public static float chaseSpeed = 10;
    public float chaseSpeedLowerLimit = 8;
    public float chaseSpeedUpperLimit = 12;

	// Use this for initialization
	void Start () {
        PlayerT = Player.PlayerTransform1;
        chaseSpeed = Random.Range(chaseSpeedLowerLimit, chaseSpeedUpperLimit);
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(PlayerT);
        transform.position += transform.forward * chaseSpeed * Time.deltaTime;
    }
}
