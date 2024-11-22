using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    //General UI
    public TextMeshProUGUI healthText;
    public Image hpImage;
    public Image bossImage;

    //For DOT attack
    public Button fireButton;
    public float damageInterval;
    public int flaskCd;
    public bool dotTrue = false;
    public int counter = 0;
    public int fireTickDmg = 1;

    //For AutoClicker
    public Toggle autoAtkButton;
    public int autoClickDmg = 1;
    public float autoClickDelay = 2.5f;

    //Monster stats
    public float hp;
    public float maxHp = 100;
    
    void Start()
    {
        hp = maxHp;
    }

    void Update()
    {
        healthText.text = "HP : " + hp.ToString("00"); //Updates the "HP" text
        hpImage.fillAmount = hp / maxHp; //Decreases the health bar as HP goes down

        if(hp <= 0)
        {
            hp = maxHp;
            bossImage.color = new Color(bossImage.color.r, bossImage.color.g, bossImage.color.b, 1);
        }

        /*if (autoAtkButton.isOn == false)
        {
            StopCoroutine(AutoClicker());
        }*/
    }

    //Attack used to damage monster
    public void PlayerAttack()
    {
        hp--;
        Color zeroAlpha= new Color (1,1,1,0);
        bossImage.color = Color.Lerp(zeroAlpha, Color.white, hp / maxHp);
    }


    //Attack used for fire DOT
    public void FireDOT()
    {
        fireButton.interactable = false; //Turns off the "Fire Flask!" button for cd
        StartCoroutine(FireDamage()); //Start DOT coroutine
        StartCoroutine(FireCd()); //Start button cd
    }

    //Used for AutoClicker
    public void AutoClickerToggle()
    {
        StartCoroutine(AutoClicker());
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~COROUTINES~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    //Used for the repeated DOT damage
    IEnumerator FireDamage()
    {
        while (counter < 7)
        {
            hp -= fireTickDmg;
            yield return new WaitForSeconds(damageInterval);
            counter += 1;
        }
        counter = 0;

    }
    //Used for the cd on the "Fire Flask!" button
    IEnumerator FireCd()
    {
        yield return new WaitForSeconds(flaskCd);
        fireButton.interactable = true;
    }

    IEnumerator AutoClicker()
    {
        while (autoAtkButton.isOn == true)
        {
            hp -= autoClickDmg;
            yield return new WaitForSeconds(autoClickDelay);
        }
    }
}
