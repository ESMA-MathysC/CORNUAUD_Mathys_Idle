using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int totalMoney = 0;
    public void UpdateMoneyUI()
    {
        _moneyText.text = totalMoney.ToString("000");
    }
}
