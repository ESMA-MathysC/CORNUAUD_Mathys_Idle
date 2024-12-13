using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int clickDamage = 1;

    public bool hasWand2Upgrade = false;
    public int critMultiplier = 1;

    [SerializeField]
    private int _critRoll;

    public void OnPlayerClick()
    {
        if(hasWand2Upgrade == true)
        {
            _critRoll = Random.Range(0, 4);
            if(_critRoll == 4)
            {
                GameManager.Instance.enemy._currentHp -= clickDamage * critMultiplier;
                GameManager.Instance.enemy._hpText.text = GameManager.Instance.enemy._currentHp.ToString("000");
                GameManager.Instance.enemy._hpImage.fillAmount = (float)GameManager.Instance.enemy._currentHp / (float)GameManager.Instance.enemy._maxHp;
            }
            else
            {
                GameManager.Instance.enemy._currentHp -= clickDamage;
                GameManager.Instance.enemy._hpText.text = GameManager.Instance.enemy._currentHp.ToString("000");
                GameManager.Instance.enemy._hpImage.fillAmount = (float)GameManager.Instance.enemy._currentHp / (float)GameManager.Instance.enemy._maxHp;
            }
        }
        else
        {
            GameManager.Instance.enemy._currentHp -= clickDamage;
            GameManager.Instance.enemy._hpText.text = GameManager.Instance.enemy._currentHp.ToString("000");
            GameManager.Instance.enemy._hpImage.fillAmount = (float)GameManager.Instance.enemy._currentHp / (float)GameManager.Instance.enemy._maxHp;
        }
        
    }
}
