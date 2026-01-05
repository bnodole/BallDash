using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int currentCoins;

    public Text coinText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            currentCoins++;
            other.gameObject.SetActive(false);
            coinText.text = currentCoins.ToString();
        }
    }
}
