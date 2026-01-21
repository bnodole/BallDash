using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    GameObject[] obstacles;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Invisible"))
        {
            obstacles = GameObject.FindGameObjectsWithTag("Bombs");
            other.gameObject.SetActive(false);
            
            StartCoroutine(ChangePowerUpStatus());
            
        }
        if (other.gameObject.CompareTag("SpeedPower"))
        {
            StartCoroutine(ChangeSpeedPowerUp());
        }
        if (other.gameObject.CompareTag("Magnet"))
        {
            StartCoroutine(CHangeMagnetPowerUp());
        }
    }
    IEnumerator ChangePowerUpStatus()
    {
        InvisiblePower(true);
        yield return new WaitForSeconds(10);
        InvisiblePower(false);
    }

    IEnumerator ChangeSpeedPowerUp()
    {
        this.GetComponent<BallScript>().speed += 10f;
        yield return new WaitForSeconds(10);
        this.GetComponent<BallScript>().speed -= 10f;
    }
    IEnumerator CHangeMagnetPowerUp()
    {
        this.GetComponent<BallScript>().magnetArea.SetActive(true);
        this.GetComponent<BallScript>().magnetArea.SetActive(true);
        yield return new WaitForSeconds(10);
        this.GetComponent<BallScript>().magnetArea.SetActive(false);
    }

    public void InvisiblePower(bool status)
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<BoxCollider>().isTrigger = status;
        }
    }
}
