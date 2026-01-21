using UnityEngine;

public class RotateCoins : MonoBehaviour
{
    public Vector3 origPosition;
    GameManager gameManager;
    bool collected = false;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        origPosition = transform.localPosition;
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, 75f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            gameManager.currentCoins++;
            gameManager.gameSounds.PlayOneShot(gameManager.coinSound);
            gameManager.coinText.text = gameManager.currentCoins.ToString();

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MagnetArea"))
        {
            if (transform.parent != null)
                transform.SetParent(null);

            transform.position = Vector3.MoveTowards(
                transform.position,
                other.transform.parent.position,
                10f * Time.deltaTime
            );
        }
    }
}
