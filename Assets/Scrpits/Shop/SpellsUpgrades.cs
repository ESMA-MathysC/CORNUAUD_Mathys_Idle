using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsUpgrades : MonoBehaviour
{
    public Button spell1Button;
    public int spell1Cost;

    public Button spell2Button;
    public int spell2Cost;

    public Button spell3Button;
    public int spell3Cost;

    void Update()
    {
        if (GameManager.Instance.enemy.hasSpell2Upgrade == true)
        {
            spell2Button.interactable = false; //so the player can only buy the upgrade once
        }
    }

    public void BuySpell1()
    {

    }
    public void BuySpell2()
    {
        if(GameManager.Instance.moneyManager.totalMoney >= spell2Cost) //if the player has enough money
        {
            GameManager.Instance.moneyManager.totalMoney -= spell2Cost; //subtract the cost from the player's total money
            GameManager.Instance.enemy.hasSpell2Upgrade = true; //activate the upgrade where the money is given to the player
            GameManager.Instance.moneyManager.UpdateMoneyUI(); //update the money UI
        }
    }
    public void BuySpell3()
    {
        if(GameManager.Instance.moneyManager.totalMoney >= spell3Cost)
        {
            if (!GameManager.Instance.playerClick.hasSpell3Upgrade)
            {
                GameManager.Instance.playerClick.hasSpell3Upgrade = true;
                GameManager.Instance.playerClick.StartSpell3();
                GameManager.Instance.playerClick.Spell3Dmg += 15;
            }
            GameManager.Instance.playerClick.Spell3Dmg += 15;
            GameManager.Instance.moneyManager.totalMoney -= spell3Cost;
            GameManager.Instance.moneyManager.UpdateMoneyUI();
            spell3Cost = spell3Cost * 2;

        }
    }
}
