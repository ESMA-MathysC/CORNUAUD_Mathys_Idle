using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int totalMoney = 0;
    public TextMeshProUGUI moneyText;

    public void Start()
    {
        UpdateMoneyUI();
    }

    public void UpdateMoneyUI()
    {
        moneyText.text = totalMoney.ToString("000");
    }
}
