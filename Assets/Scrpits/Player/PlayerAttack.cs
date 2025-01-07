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

    //~~~~~~~~~~~~~~~~SPELL 3//~~~~~~~~~~~~~~~~
    public bool hasSpell3Upgrade = false;
    public int Spell3Dmg;
    public int Spell3Delay;

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

    public void StartSpell3()
    {
        StartCoroutine(Spell3Attack());
    }

    public IEnumerator AutoClicker()
    {
        while (hasAutoClicker)
        {
            GameManager.Instance.enemy.currentHp -= autoClickDmg;
            GameManager.Instance.enemy.hpText.text = GameManager.Instance.enemy.currentHp.ToString("000");
            GameManager.Instance.enemy.hpImage.fillAmount = (float)GameManager.Instance.enemy.currentHp / (float)GameManager.Instance.enemy.maxHp;
            yield return new WaitForSeconds(autoClickDelay);
        }
    }

    public IEnumerator Spell3Attack()
    {
        while (hasSpell3Upgrade)
        {
            GameManager.Instance.enemy.currentHp -= Spell3Dmg;
            GameManager.Instance.enemy.hpText.text = GameManager.Instance.enemy.currentHp.ToString("000");
            GameManager.Instance.enemy.hpImage.fillAmount = (float)GameManager.Instance.enemy.currentHp / (float)GameManager.Instance.enemy.maxHp;
            yield return new WaitForSeconds(Spell3Delay);
        }
    }
}