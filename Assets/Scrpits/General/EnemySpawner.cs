using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public int currentHp;
    public int maxHp;
    [SerializeField]
    public TextMeshProUGUI hpText, nameText, typeText, rarityText, moneyText;
    [SerializeField]
    private Image _enemyImage;
    [SerializeField]
    public Image hpImage;

    public bool hasSpell2Upgrade = false;

    [SerializeField]
    private Enemy _currentEnemy;

    public Animator anim;

    [SerializeField]
    private WeightedList<Enemy> _enemyTable;

    void Start()
    {
        ReadEnemy(_enemyTable.GetRandomElement());
    }

    void Update()
    {
        if (currentHp == 1)
        {
            anim.speed = 2;
        }
        if (currentHp <= 0)
        {
            GameManager.Instance.moneyManager.totalMoney += _currentEnemy.lootAmount; //adds the looting amount of the ressource to the player's money count
            if (hasSpell2Upgrade)
            {
                GameManager.Instance.moneyManager.totalMoney += _currentEnemy.lootAmount / 2;
            }
            GameManager.Instance.moneyManager.UpdateMoneyUI();
            //_enemyTable.GetRandomElement();
            ReadEnemy(_enemyTable.GetRandomElement());
            //ReadEnemy(_enemyTable[Random.Range(0, _enemyTable._weightedElementsList.Count)]);

        }
    }

    //read a new enemy, refreshing every information onscreen about it
    private void ReadEnemy(Enemy newEnemy)
    {
        _currentEnemy = newEnemy;

        currentHp = _currentEnemy.hp;
        maxHp = _currentEnemy.hp;
        hpImage.fillAmount = 1;

        hpText.text = _currentEnemy.hp.ToString("000");
        nameText.text = _currentEnemy.enemyName.ToString();
        typeText.text = _currentEnemy.type.ToString();
        rarityText.text = _currentEnemy.rarity.ToString();
        anim.runtimeAnimatorController = _currentEnemy.animator;
        anim.speed = 1;

        _enemyImage.sprite = _currentEnemy.enemyImage;
    }
}
