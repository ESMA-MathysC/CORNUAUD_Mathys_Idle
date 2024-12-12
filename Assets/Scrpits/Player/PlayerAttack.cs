using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int clickDamage = 1;
    public void OnPlayerClick()
    {
        GameManager.Instance.enemy._currentHp -= clickDamage;
        GameManager.Instance.enemy._hpText.text = GameManager.Instance.enemy._currentHp.ToString("000");
        GameManager.Instance.enemy._hpImage.fillAmount = (float)GameManager.Instance.enemy._currentHp / (float)GameManager.Instance.enemy._maxHp;
    }
}
