using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public Rigidbody ballRigidBody;
    public float speed;
    public bool canJump = true;
    public int horizontalMovement;

    public float distance;
    public Vector3 startPosition;
    public GameObject gamePlayUI;
    public int currentScore;
    public Text scoreText;
    public int highScore;

    public int totalCoins;
    public CoinManager coinManager;

    public GameObject deathUI;
    public Text highscore;
    public Text currentScoreUI;
    public Text currentCoinsUI;
    public Text totalCoinsUI;


    public GameObject pauseUI;
    bool isGamePaused;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        coinManager = GetComponent<CoinManager>();
        highScore = PlayerPrefs.GetInt("Highscore");
        totalCoins = PlayerPrefs.GetInt("Coins");
        deathUI.SetActive(false);
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BallMovement();
        ScoreManager();
        PauseGame();
        speed += 0.005f*Time.deltaTime;
    }

    void BallMovement()
    {
        //Continuous ball movement
        ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x, ballRigidBody.velocity.y, speed);
        //float horizontalMovement = Mathf.Ceil( Input.GetAxis("Horizontal"))*3;

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(horizontalMovement > -3)
                horizontalMovement -= 3; 
        }if (Input.GetKeyDown(KeyCode.D))
        {
            if (horizontalMovement < 3)
                horizontalMovement += 3;
        }
        var lerpXValue = Vector3.Lerp(ballRigidBody.transform.position,new Vector3(horizontalMovement,0,0),10*Time.deltaTime);

        ballRigidBody.transform.position = new Vector3(lerpXValue.x, ballRigidBody.transform.position.y, ballRigidBody.transform.position.z);

        //Side Movement
        ballRigidBody.velocity = new Vector3(0, ballRigidBody.velocity.y, ballRigidBody.velocity.z);

        //Jump
        if (Input.GetButtonDown("Jump") && canJump)
        {
            ballRigidBody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            canJump = false;
        }
    }

    void ScoreManager()
    {
        distance = transform.position.z - startPosition.z;
        currentScore = (int)distance*10;
        scoreText.text = currentScore.ToString();
    }

    void Death()
    {
        Debug.Log("Death");
        Debug.Log("Score: " + currentScore);
        if(currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("Highscore", highScore);
            Debug.Log("NEW HIGHSCORE");
        }
        totalCoins += coinManager.currentCoins;
        PlayerPrefs.SetInt("Coins", totalCoins);
        Debug.Log(PlayerPrefs.GetInt("Coins"));
        gamePlayUI.SetActive(false);
        deathUI.SetActive(true);
        Time.timeScale = 0f;
        highscore.text = "Highscore: " + highScore.ToString();
        currentCoinsUI.text = coinManager.currentCoins.ToString();
        currentScoreUI.text = "Score" + currentScore.ToString();
        totalCoinsUI.text = totalCoins.ToString();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Time.timeScale = 1f;
                pauseUI.SetActive(false);
                isGamePaused = false;
            }
            else
            {
                Time.timeScale = 0f;
                pauseUI.SetActive(true);
                isGamePaused = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Base")
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Bombs"))
        {
            Death();
        }
    }
}
