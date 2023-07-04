using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen2 : MonoBehaviour
{
    public Text accountBalanceText;
    //public int accountBalance;
    // Start is called before the first frame update
    void Start()
    {
        AcountBalanceUpdater.Instance.accountBalance = PlayerPrefs.GetInt("accountBalance");
        accountBalanceText.text = "Account Balance" + AcountBalanceUpdater.Instance.accountBalance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
