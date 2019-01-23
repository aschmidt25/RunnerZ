using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static int score = 0;
    public int scoreDistance;
    private Vector3 spawnPos;
    public float spawnDistance = 49f;
    public int horizontalSpeed = 10;
    public float forwardSpeed = 15f;
    public float dashForce = 200f;
    private float dashTime = 10f;
    public float dashStartTime = 10f;
    public float startDashTime;
    public bool isDashingLeft = false;
    public bool isDashingRight = false;
    public float dashTimer = 5;
    public int jumpForce = 5;
    public int arrSize;
    public float speedIncrease = .25f;
    public float speedMax = 18;
    public float speedIncreaseDistance = 200f;
    private int speedMultiplier = 1;
    private int scoreMultiplier = 1;
    public Text scoreText;
    public int winScore = 0;
    public Slider distanceBar;
    public float currentDistance { get; set; }
    public float maxDistance { get; set; }

    public GameObject[] setPieceArr;
    private GameObject playerEmpty;
    private Rigidbody playerBody;
    public GameObject CPMenu;
    public GameObject Shield;
    public GameObject Slow;
    public GameObject Speedup;
    public GameObject ShieldDetails;
    public GameObject SpeedDetails;
    public GameObject SlowMoDetails;

    private Vector2 touchOrigin = -Vector2.one;

    public float deathDistance = 15.91f;
    public GameObject deathObject;
    public Transform PlayerTransform;
    public static Transform PlayerTransform1;

    public static int lives = 3;
    public int speedUpTime = 10;
    public int shieldTime = 10;
    public int slowTime = 10;
    public bool startSpeedUp = false;
    public bool startShield = false;
    public bool startSlow = false;
    public static bool SlowTUT = true;
    public static bool SpeedTUT = true;
    public static bool ShieldTUT = true;

    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        playerEmpty = GameObject.FindGameObjectWithTag("PlayerPos");
        playerBody = gameObject.GetComponent<Rigidbody>();
        CPMenu.SetActive(false);
        Shield.SetActive(false);
        Speedup.SetActive(false);
        Slow.SetActive(false);
        ShieldDetails.SetActive(false);
        SpeedDetails.SetActive(false);
        SlowMoDetails.SetActive(false);
        maxDistance = 20f;
        currentDistance = deathDistance;
        PlayerTransform1 = PlayerTransform;
        lives = 3;
        score = 0;
        dashTime = dashStartTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        //make set pieces spawn in front of player
        if(other.tag == "SetPieceSpawnPoint")
        {
            Instantiate(setPieceArr[Random.Range(0, arrSize)], spawnPos, Quaternion.identity);
        }

        //checkpoints
        if (other.tag == "Checkpoint")
        {
            Debug.Log("Checkpoint");
            CPMenu.SetActive(true);
            Time.timeScale = 0f;
            Pause_Menu.GameIsPaused = true;
        }

        //restart
        if(other.tag == "Restart")
        {
            //load current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }

        if(other.tag == "Loot")
        {
            score += 10;
            UpdateScore();
        }

        if(other.tag == "SpeedUp")
        {

            if (SpeedTUT)
            {
                SpeedDetails.SetActive(true);
                Time.timeScale = 0f;
                Pause_Menu.GameIsPaused = true;
                Debug.Log("speed tutorial");
            }
            SpeedTUT = false;
            StartCoroutine(SpeedUpTimer());

        }

        if(other.tag == "Slow")
        {
            if (SlowTUT)
            {
                SlowMoDetails.SetActive(true);
                Time.timeScale = 0f;

                Pause_Menu.GameIsPaused = true;
                Debug.Log("slow tutorial");
            }
            SlowTUT = false;
            
            StartCoroutine(SlowTimer());
        }

        if(other.tag == "Shield")
        {
            if (ShieldTUT)
            {
                ShieldDetails.SetActive(true);
                Time.timeScale = 0f;

                Pause_Menu.GameIsPaused = true;
                Debug.Log("shield tutorial");
            }
            ShieldTUT = false;
            lives += 1;
            
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Supplies: " + score.ToString() + "/750";
    }

    public void DashLeft()
    {
        if (!isDashingLeft)
        {
            transform.position += Vector3.left * dashForce * Time.deltaTime;
            StartCoroutine(DashLeftTimer());
        }
        
     }

    public void DashRight()
    {
        if (!isDashingRight)
        {
            transform.position += Vector3.right * dashForce * Time.deltaTime;
            StartCoroutine(DashRightTimer());
        }
    }

    IEnumerator DashLeftTimer()
    {
        isDashingLeft = true;
        yield return new WaitForSeconds(dashTimer);
        isDashingLeft = false;
    }

    IEnumerator DashRightTimer()
    {
        isDashingRight = true;
        yield return new WaitForSeconds(dashTimer);
        isDashingRight = false;
    }

    IEnumerator SlowTimer()
    {
        Slow.SetActive(true);
        EnemyScript.chaseSpeed -= 4;
        TimeScript.deleteTime = true;
        yield return new WaitForSeconds(10);
        Slow.SetActive(false);
        EnemyScript.chaseSpeed += 4;
        TimeScript.deleteTime = false;
    }

    IEnumerator SpeedUpTimer()
    {
        Speedup.SetActive(true);
        forwardSpeed += 5;
        SpeedScript.deleteSpeed = true;
        yield return new WaitForSeconds(10);
        Speedup.SetActive(false);
        forwardSpeed -= 5;
        SpeedScript.deleteSpeed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives >=4)
        {
            Shield.SetActive(true);
        }
        else
        {
            Shield.SetActive(false);
        }

        if (lives < 1)
        {
            SceneManager.LoadScene(3);
        }

        //win condition
        if(score == winScore)
        {
            SceneManager.LoadScene(4);
        }

        if (speedUpTime == 0)
        {
            startSpeedUp = false;
            Speedup.SetActive(false);
            speedUpTime = 10;
            forwardSpeed -= 5;
        }

        if (startSpeedUp == true)
        {
            Speedup.SetActive(true);
            Speedup.SetActive(false);
        }

        if (slowTime == 0)
        {
            startSlow = false;
            Slow.SetActive(false);
            slowTime = 10;
            EnemyScript.chaseSpeed += 4;
        }

        if(startSlow == true)
        {
            Slow.SetActive(true);
            yield return new WaitForSeconds(10);
            Slow.SetActive(false);
        }

        if (shieldTime == 0)
        {
            startShield = false;
            shieldTime = 10;
        }

        if(startShield == true)
        {
            shieldTime -= 1;
        }
        


        if (Input.GetKeyDown("space") && transform.position.y <= 2.5)
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
        }

        //dash left
        if (Input.GetKeyDown(KeyCode.D) && !isDashingLeft)
        {
            DashLeft();
            
        }

        //dash right
        if (Input.GetKeyDown(KeyCode.F) && !isDashingRight)
        {
            Debug.Log("DASH RIGHT");
            DashRight();
            
        }

        
        spawnPos = new Vector3(playerEmpty.transform.position.x, 0f, playerEmpty.transform.position.z);
        spawnPos.z += spawnDistance;

       

        //speed increase
        if(forwardSpeed != speedMax)
        {
            if(transform.position.z - speedIncreaseDistance*speedMultiplier >= 0)
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
