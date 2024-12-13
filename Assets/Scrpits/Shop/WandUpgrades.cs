using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandUpgrades : MonoBehaviour
{
    public int wand1Cost = 30;

    public int wand2Cost = 500;

    public void BuyWand1()
    {
        if(GameManager.Instance.totalMoney >= wand1Cost)
        {
            GameManager.Instance.totalMoney -= wand1Cost;
            GameManager.Instance.playerClick.clickDamage = GameManager.Instance.playerClick.clickDamage * 2;
            wand1Cost = wand1Cost * 2;
            GameManager.Instance.enemy.UpdateMoneyUI();
            GameManager.Instance.shopPrices.UpdatePriceWand1();
        }

    }

    public void BuyWand2()
    {
        if (GameManager.Instance.totalMoney >= wand2Cost)
        {
            if (!GameManager.Instance.playerClick.hasWand2Upgrade)
            {
                GameManager.Instance.playerClick.hasWand2Upgrade = true;
                GameManager.Instance.totalMoney -= wand2Cost;
                GameManager.Instance.playerClick.critMultiplier += 1;
                wand2Cost = wand2Cost * 2;
                GameManager.Instance.enemy.UpdateMoneyUI();
                GameManager.Instance.shopPrices.UpdatePriceWand2();
            }
            else
            {
                GameManager.Instance.totalMoney -= wand2Cost;
                GameManager.Instance.playerClick.critMultiplier += 1;
                wand2Cost = wand2Cost * 2;
                GameManager.Instance.enemy.UpdateMoneyUI();
                GameManager.Instance.shopPrices.UpdatePriceWand2();
            }
        }
    }
}
