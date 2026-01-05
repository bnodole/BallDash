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

    public float distance;
    public Vector3 startPosition;
    public int currentScore;
    public Text scoreText;
    public int highScore;

    public int totalCoins;
    public CoinManager coinManager;

    public GameObject deathUI;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        coinManager = GetComponent<CoinManager>();
        highScore = PlayerPrefs.GetInt("Highscore");
        totalCoins = PlayerPrefs.GetInt("Coins");
        deathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BallMovement();
        ScoreManager();
    }

    void BallMovement()
    {
        //Continuous ball movement
        ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x, ballRigidBody.velocity.y, speed);

        //Side Movement
        float horizontalMovement = Input.GetAxis("Horizontal") * speed;
        ballRigidBody.velocity = new Vector3(horizontalMovement, ballRigidBody.velocity.y, ballRigidBody.velocity.z);

        //Jump
        if (Input.GetButtonDown("Jump") && canJump)
        {
            ballRigidBody.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
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
        deathUI.SetActive(true);
        Time.timeScale = 0f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
