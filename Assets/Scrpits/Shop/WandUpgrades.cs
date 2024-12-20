using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WandUpgrades : MonoBehaviour
{
    public Button wand1Button;
    public int wand1Cost;

    public Button wand2Button;
    public int wand2Cost;

    public Button wand3Button;
    public int wand3Cost;

    public void Update()
    {
        if (GameManager.Instance.playerClick.autoClickDelay == 0.25f)
        {
            wand3Button.interactable = false; //used to cap the number of times it can be bought
        }
    }

    public void BuyWand1()
    {
        if(GameManager.Instance.moneyManager.totalMoney >= wand1Cost)
        {
            GameManager.Instance.moneyManager.totalMoney -= wand1Cost;
            wand1Cost = wand1Cost * 2;
            GameManager.Instance.moneyManager.UpdateMoneyUI();
            GameManager.Instance.shopPrices.UpdatePriceWand1UI();
            if(GameManager.Instance.playerClick.clickDamage < 5)
            {
                GameManager.Instance.playerClick.clickDamage += 1;
            }
            if(GameManager.Instance.playerClick.clickDamage > 5)
            {
                GameManager.Instance.playerClick.clickDamage += 2;
            }
        }
    }

    public void BuyWand2()
    {
        if(GameManager.Instance.moneyManager.totalMoney >= wand2Cost) //if the player has enough money
        {
            if(!GameManager.Instance.playerClick.hasWand2Upgrade) //if he DOESN'T have the crit upgrade yet
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

    public void BuyWand3()
    {
        if(GameManager.Instance.moneyManager.totalMoney >= wand3Cost) //if the player has enough money
        {
            if(!GameManager.Instance.playerClick.hasAutoClicker) //if he doesn't have the autocliker yet
            {
                GameManager.Instance.playerClick.hasAutoClicker = true; //activate "has autoclicker" flag
                GameManager.Instance.playerClick.StartAutoClicker(); //start coroutine for the first time
            }
            if(GameManager.Instance.playerClick.hasAutoClicker) //if player already has autoclicker
            {
                if(GameManager.Instance.playerClick.autoClickDelay <= 1) //if autoclick delay is below equal or below 1 sec, divide it by 2
                {
                    GameManager.Instance.playerClick.autoClickDelay = GameManager.Instance.playerClick.autoClickDelay / 2;
                }
                if(GameManager.Instance.playerClick.autoClickDelay > 1) //if autoclick delay is above one (5 to 2 secs) lower it by one
                {
                    GameManager.Instance.playerClick.autoClickDelay -= 1;
                }
                if(GameManager.Instance.playerClick.autoClickDelay == 2)
                {
                    GameManager.Instance.playerClick.autoClickDmg += 1;
                }
                if (GameManager.Instance.playerClick.autoClickDelay == 0.25f)
                {
                    GameManager.Instance.playerClick.autoClickDmg += 2;
                }
            }
            GameManager.Instance.moneyManager.totalMoney -= wand3Cost;
            GameManager.Instance.moneyManager.UpdateMoneyUI();
            wand3Cost = wand3Cost * 2; //increase price of upgrade
            GameManager.Instance.shopPrices.UpdatePriceWand3UI();
        }
    }
}
