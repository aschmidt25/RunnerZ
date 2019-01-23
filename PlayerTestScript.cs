using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTestScript : MonoBehaviour {
    public static int score = 0;
    public int scoreDistance;
    private Vector3 spawnPos;
    public float spawnDistance = 49f;
    public int horizontalSpeed = 10;
    public float forwardSpeed = 15f;
    public int jumpForce = 5;
    public int arrSize;
    public float speedIncrease = .25f;
    public float speedMax = 18;
    public float speedIncreaseDistance = 200f;
    private int speedMultiplier = 1;
    private int scoreMultiplier = 1;
    public int winScore = 0;
    public float currentDistance { get; set; }
    public float maxDistance { get; set; }

    public GameObject[] setPieceArr;
    private GameObject playerEmpty;
    private Rigidbody playerBody;

    private Vector2 touchOrigin = -Vector2.one;

    public float deathDistance = 15.91f;
    public GameObject deathObject;


    // Use this for initialization
    void Start()
    {
        playerEmpty = GameObject.FindGameObjectWithTag("PlayerPos");
        playerBody = gameObject.GetComponent<Rigidbody>();
        maxDistance = 20f;
        currentDistance = deathDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        //make set pieces spawn in front of player
        if (other.tag == "SetPieceSpawnPoint")
        {
            Instantiate(setPieceArr[Random.Range(0, arrSize)], spawnPos, Quaternion.identity);
        }

        //checkpoints
        if (other.tag == "Checkpoint")
        {
            Debug.Log("Checkpoint");
            Time.timeScale = 0f;
            Pause_Menu.GameIsPaused = true;
        }

        //restart
        if (other.tag == "Restart")
        {
            //load current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }

        if (other.tag == "Loot")
        {
            score += 10;
            UpdateScore();
        }

        
    }




    // Update is called once per frame
    void Update()
    {
        //win condition
        if (score == winScore)
        {
            SceneManager.LoadScene(4);
        }

        if (Input.GetKeyDown("space") && transform.position.y <= 2.5)
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
        }

        //deathDistance work
        deathDistance = transform.position.z - deathObject.transform.position.z;
        currentDistance = deathDistance;

        spawnPos = new Vector3(playerEmpty.transform.position.x, 0f, playerEmpty.transform.position.z);
        spawnPos.z += spawnDistance;



        //speed increase
        if (forwardSpeed != speedMax)
        {
            if (transform.position.z - speedIncreaseDistance * speedMultiplier >= 0)
            {
                forwardSpeed += speedIncrease;
                speedMultiplier += 1;
                Debug.Log("Speed changed to" + forwardSpeed);
            }


        }

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        {


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }
#else
        /* int count = 0;
         while (count < Input.touchCount)
         {
             if (Input.GetTouch (count).position.x > Screen.width / 2)
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
         */

        if (Input.touchCount == 1)
        {
            Touch myTouch = Input.GetTouch(0);
            Vector3 screensize = new Vector3(Screen.currentResolution.width, Screen.currentResolution.height);
            if (myTouch.position.x < screensize.x / 2)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }

            if (myTouch.position.x > screensize.x / 2)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
            //touchOrigin = myTouch.position;
            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                touchOrigin.x = -1;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    horizontalSpeed = x > 0 ? 1 : -1;

                }
            }

        }
#endif



        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);


    }
}
