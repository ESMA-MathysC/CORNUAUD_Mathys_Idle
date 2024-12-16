using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandUpgrades : MonoBehaviour
{
    public int wand1Cost;

    public int wand2Cost;

    public void BuyWand1()
    {
        if(GameManager.Instance.moneyManager.totalMoney >= wand1Cost)
        {
            GameManager.Instance.moneyManager.totalMoney -= wand1Cost;
            wand1Cost = wand1Cost * 2;
            GameManager.Instance.moneyManager.UpdateMoneyUI();
            GameManager.Instance.shopPrices.UpdatePriceWand1UI();
            if (GameManager.Instance.playerClick.clickDamage < 5)
            {
                GameManager.Instance.playerClick.clickDamage += 1;
            }
            if (GameManager.Instance.playerClick.clickDamage > 5)
            {
                GameManager.Instance.playerClick.clickDamage += 2;
            }
        }
    }

    public void BuyWand2()
    {
        if (GameManager.Instance.moneyManager.totalMoney >= wand2Cost) //if the player has enough money
        {
            if (!GameManager.Instance.playerClick.hasWand2Upgrade) //if he DOESN'T have the crit upgrade yet
            {
                GameManager.Instance.playerClick.hasWand2Upgrade = true; //then we activate the "has crits" flag
            }
            GameManager.Instance.playerClick.critMultiplier += 1; //we increase the crit multiplier by 1 (the first time it increases it become *2)
            GameManager.Instance.moneyManager.totalMoney -= wand2Cost; //we deduct the player money
            GameManager.Instance.moneyManager.UpdateMoneyUI(); //we update the money UI
            wand2Cost = wand2Cost * 2; //we increase the price of the upgrade
            GameManager.Instance.shopPrices.UpdatePriceWand2UI(); //we update the price UI

        }
    }
}
