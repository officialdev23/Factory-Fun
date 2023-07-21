using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawMaterialPurchase : MonoBehaviour
{
    public GameObject buyButton;

    public int expense;
    public int accountBal;

    public List<int> productPrice;
    public List<int> selectedQty;
    public List<int> selectedPrice;
    public List<int> inventoryQty;
    public List<Text> selectedQtyText;
    public List<Text> selectedPriceText;
    public List<Text> inventoryQtyText;

    void Start()
    {
        foreach (int price in productPrice)
        {
            Debug.Log("Raw material price: " + price);
        }
    }

    private void Update()
    {
        expense = selectedPrice[0] + selectedPrice[1];
        accountBal = PlayerPrefs.GetInt("accountBalance");
        if (expense > accountBal)
        {
            buyButton.SetActive(false);
        }
        else
        {
            buyButton.SetActive(true);
        }
    }

    public void IncreaseQty(int productId)
    {
        selectedQty[productId]++;
        selectedPrice[productId] = productPrice[productId] * selectedQty[productId];
        selectedQtyText[productId].text = " "+ selectedQty[productId];
        selectedPriceText[productId].text = "$" + selectedPrice[productId];
    }

    public void DecreaseQty(int productId)
    {
        selectedQty[productId]--;
        if (selectedQty[productId] < 0)
        {
            selectedQty[productId] = 0;
        }
        selectedPrice[productId] = productPrice[productId] * selectedQty[productId];
        
        selectedQtyText[productId].text = " " + selectedQty[productId];
        selectedPriceText[productId].text = "$" + selectedPrice[productId];
    }

    public void OnBuy()
    {
        inventoryQty[0] = inventoryQty[0] + selectedQty[0];
        inventoryQty[1] = inventoryQty[1] + selectedQty[1];
        Debug.Log(selectedQty[1] + "Inventory of product index 1");
        //foreach (int qty in inventoryQty)
        //{
        //    inventoryQty[qty] = inventoryQty[qty] + selectedQty[qty];
        //    //Debug.Log("Raw material price: " + price);
        //}


        UpdatePlayerPrefs();
        SetInventoryText();
        updateAccountBalance();
        ResetUpdatedStats();
    }

    public void SetInventoryText()
    {
        inventoryQtyText[0].text = "" + PlayerPrefs.GetInt("Product1");
        inventoryQtyText[1].text = "" + PlayerPrefs.GetInt("Product2");
    }

    public void UpdatePlayerPrefs()
    {
        PlayerPrefs.SetInt("Product1", inventoryQty[0]);
        PlayerPrefs.SetInt("Product2", inventoryQty[1]);
        Debug.Log(PlayerPrefs.GetInt("Product1"));
    }


    public void updateAccountBalance()
    {
        
        
            accountBal = accountBal - expense;
            PlayerPrefs.SetInt("accountBalance", accountBal);
        
    }

    public void ResetUpdatedStats()
    {
        for(int i = 0; i <= 1; i++)
        {
            selectedQtyText[i].text = "0";
            selectedQty[i] = 0;
            selectedPriceText[i].text = "$ 0 ";
            selectedPrice[i] = 0;
        }
    }
}
