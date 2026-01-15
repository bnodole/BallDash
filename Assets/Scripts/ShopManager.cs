using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text coins;
    int coin;
    public Button[] buyButton;
    public Button[] selectButton;
    int price;
    public Transform itemHolder;

    private void Update()
    {
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
        coin = PlayerPrefs.GetInt("Coins");
        if(PlayerPrefs.GetInt("isItem1Bought") == 1)
        {
            buyButton[0].gameObject.SetActive(false);
            selectButton[0].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("isItem2Bought") == 1)
        {
            buyButton[1].gameObject.SetActive(false);
            selectButton[1].gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isItem3Bought") == 1)
        {
            buyButton[1].gameObject.SetActive(false);
            selectButton[1].gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isItem4Bought") == 1)
        {
            buyButton[1].gameObject.SetActive(false);
            selectButton[1].gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isItem5Bought") == 1)
        {
            buyButton[1].gameObject.SetActive(false);
            selectButton[1].gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isItem6Bought") == 1)
        {
            buyButton[1].gameObject.SetActive(false);
            selectButton[1].gameObject.SetActive(true);
        }
    }

    public void BuyItem(int itemIndex)
    {
        price = int.Parse(itemHolder.GetChild(itemIndex).GetChild(1).GetComponent<Text>().text);
        if (coin >= price)
        {
            switch (itemIndex)
            {
                case 0:
                    coin -= price;
                    PlayerPrefs.SetInt("Coins", coin);
                    PlayerPrefs.SetInt("isItem1Bought", 1);
                    buyButton[itemIndex].gameObject.SetActive(false);
                    selectButton[itemIndex].gameObject.SetActive(true);
                    break;
                case 1:
                    coin -= price;
                    PlayerPrefs.SetInt("Coins", coin);
                    PlayerPrefs.SetInt("isItem2Bought", 1);
                    buyButton[itemIndex].gameObject.SetActive(false);
                    selectButton[itemIndex].gameObject.SetActive(true);
                    break;
                case 2:
                    coin -= price;
                    PlayerPrefs.SetInt("Coins", coin);
                    PlayerPrefs.SetInt("isItem3Bought", 1);
                    buyButton[itemIndex].gameObject.SetActive(false);
                    selectButton[itemIndex].gameObject.SetActive(true);
                    break;
                case 3:
                    coin -= price;
                    PlayerPrefs.SetInt("Coins", coin);
                    PlayerPrefs.SetInt("isItem4Bought", 1);
                    buyButton[itemIndex].gameObject.SetActive(false);
                    selectButton[itemIndex].gameObject.SetActive(true);
                    break;
                case 4:
                    coin -= price;
                    PlayerPrefs.SetInt("Coins", coin);
                    PlayerPrefs.SetInt("isItem5Bought", 1);
                    buyButton[itemIndex].gameObject.SetActive(false);
                    selectButton[itemIndex].gameObject.SetActive(true);
                    break;
                case 5:
                    coin -= price;
                    PlayerPrefs.SetInt("Coins", coin);
                    PlayerPrefs.SetInt("isItem6Bought", 1);
                    buyButton[itemIndex].gameObject.SetActive(false);
                    selectButton[itemIndex].gameObject.SetActive(true);
                    break;
            }
        }
        else
        {
            Debug.Log("Insufficient Balance");
        }
    }

    public void BuyButton(int itemIndex)
    {
        switch (itemIndex)
        {
            case 0:
                BuyItem(itemIndex);
                break;
            case 1:
                BuyItem(itemIndex);
                break;
            case 2:
                BuyItem(itemIndex);
                break;
            case 3:
                BuyItem(itemIndex);
                break;
            case 4:
                BuyItem(itemIndex);
                break;
            case 5:
                BuyItem(itemIndex);
                break;
        }
    }

    public void SelectButton(int itemIndex)
    {
        switch (itemIndex)
        {
            case 0:
                PlayerPrefs.SetInt("EquippedSkin", itemIndex);
                break;
            case 1:
                PlayerPrefs.SetInt("EquippedSkin", itemIndex);
                break;
            case 2:
                PlayerPrefs.SetInt("EquippedSkin", itemIndex);
                break;
            case 3:
                PlayerPrefs.SetInt("EquippedSkin", itemIndex);
                break;
            case 4:
                PlayerPrefs.SetInt("EquippedSkin", itemIndex);
                break;
            case 5:
                PlayerPrefs.SetInt("EquippedSkin", itemIndex);
                break;
        }
    }
}
