using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //~~~~~~~~~~~~~~~~BASE CLICK~~~~~~~~~~~~~~~~~~~~
    public int clickDamage;

    //~~~~~~~~~~~~~~~~CRIT~~~~~~~~~~~~~~~~~~~~
    public bool hasWand2Upgrade = false;
    public int critMultiplier;
    [SerializeField]
    private int _critRoll;

    //~~~~~~~~~~~~~~~~AUTOCLICKER~~~~~~~~~~~~~~~~~~~~
    public bool hasAutoClicker = false;
    public int autoClickDmg;
    public float autoClickDelay;

    public void OnPlayerClick()
    {
        if(hasWand2Upgrade)
        {
            _critRoll = Random.Range(0, 5);
            if(_critRoll == 4)
            {
                GameManager.Instance.enemy.currentHp -= clickDamage * critMultiplier;
                GameManager.Instance.enemy.hpText.text = GameManager.Instance.enemy.currentHp.ToString("000");
                GameManager.Instance.enemy.hpImage.fillAmount = (float)GameManager.Instance.enemy.currentHp / (float)GameManager.Instance.enemy.maxHp;
            }
            else
            {
                GameManager.Instance.enemy.currentHp -= clickDamage;
                GameManager.Instance.enemy.hpText.text = GameManager.Instance.enemy.currentHp.ToString("000");
                GameManager.Instance.enemy.hpImage.fillAmount = (float)GameManager.Instance.enemy.currentHp / (float)GameManager.Instance.enemy.maxHp;
            }
        }
        else
        {
            GameManager.Instance.enemy.currentHp -= clickDamage;
            GameManager.Instance.enemy.hpText.text = GameManager.Instance.enemy.currentHp.ToString("000");
            GameManager.Instance.enemy.hpImage.fillAmount = (float)GameManager.Instance.enemy.currentHp / (float)GameManager.Instance.enemy.maxHp;
        }
        GameManager.Instance.enemy.anim.SetTrigger("hit");
        
    }

    public void StartAutoClicker()
    {
        StartCoroutine(AutoClicker());
    }

    IEnumerator AutoClicker()
    {
        while (hasAutoClicker)
        {
            GameManager.Instance.enemy.currentHp -= autoClickDmg;
            GameManager.Instance.enemy.hpText.text = GameManager.Instance.enemy.currentHp.ToString("000");
            GameManager.Instance.enemy.hpImage.fillAmount = (float)GameManager.Instance.enemy.currentHp / (float)GameManager.Instance.enemy.maxHp;
            yield return new WaitForSeconds(autoClickDelay);
        }
    }
}
