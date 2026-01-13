using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int currentCoins;

    public Text coinText;

    public AudioSource gameSounds;
    public AudioClip coinSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            currentCoins++;
            gameSounds.PlayOneShot(coinSound);
            other.gameObject.SetActive(false);
            coinText.text = currentCoins.ToString();
        }
    }
}
