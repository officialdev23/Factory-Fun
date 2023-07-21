using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcountBalanceUpdater : MonoBehaviour
{
    public static AcountBalanceUpdater Instance { get; private set; }

    public Text accountBalanceText;
    public Text royaltyTokenText;
    public int accountBalance = 100;
    public int royaltyToken = 0;

    public GameObject screen1;
    public GameObject screen2;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
        PlayerPrefs.SetInt("accountBalance", 1000);
    }
    // Update is called once per frame
    void Update()
    {
        accountBalance = PlayerPrefs.GetInt("accountBalance");
        Debug.Log(accountBalance + "is the balance");
        //accountBalance++;
        //royaltyToken++;
        accountBalanceText.text = "Account Balance:" + accountBalance;
        royaltyTokenText.text = "Royalty Tokens:" + royaltyToken;
    }

    public void changeScreen()
    {
        accountBalance = accountBalance + 100;
        //PlayerPrefs.SetInt("accountBalance", accountBalance);

        screen1.SetActive(false);
        screen2.SetActive(true);
    }

    //box differnece is of 130;
    public void UpdateBalance() // pass this function when ever there is a chnage in screen and in the script of next screen set object of both the texts and use getint to get the vakues and pass it in accountBalance instace and put it in text
    {
         PlayerPrefs.SetInt("accountBalance",accountBalance);
        PlayerPrefs.SetInt("royaltyToken", royaltyToken);
        //accountBalanceText.text = "Account Balance:" + accountBalance;
    }

    public void UpdateAfterTransactions()
    {
        int accountBal = PlayerPrefs.GetInt("accountBalance");
        accountBalanceText.text = "Account Balance:" + accountBal;
    }
}
