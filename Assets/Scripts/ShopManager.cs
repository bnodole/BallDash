using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text coins;
    int coin;

    public Button[] buyButton;
    public Button[] selectButton;

    public Transform itemHolder;

    void Start()
    {
        UpdateShopUI();
    }

    void UpdateShopUI()
    {
        coin = PlayerPrefs.GetInt("Coins", 0);
        coins.text = coin.ToString();

        for (int i = 0; i < buyButton.Length; i++)
        {
            bool isBought = PlayerPrefs.GetInt("isItem" + (i + 1) + "Bought", 0) == 1;

            buyButton[i].gameObject.SetActive(!isBought);
            selectButton[i].gameObject.SetActive(isBought);
        }
    }

    public void BuyItem(int itemIndex)
    {
        int price = int.Parse(
            itemHolder.GetChild(itemIndex).GetChild(1).GetComponent<Text>().text
        );

        if (coin < price)
        {
            Debug.Log("Insufficient Balance");
            return;
        }

        coin -= price;
        PlayerPrefs.SetInt("Coins", coin);
        PlayerPrefs.SetInt("isItem" + (itemIndex + 1) + "Bought", 1);

        UpdateShopUI();
    }

    public void BuyButton(int itemIndex)
    {
        BuyItem(itemIndex);
    }

    public void SelectButton(int itemIndex)
    {
        PlayerPrefs.SetInt("EquippedSkin", itemIndex);
        Debug.Log("Selected Item: " + itemIndex);
    }
}
