using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public int _currentHp;
    public int _maxHp;
    [SerializeField]
    public TextMeshProUGUI _hpText, _nameText, _typeText, _rarityText, _moneyText;
    [SerializeField]
    private Image _enemyImage;
    [SerializeField]
    public Image _hpImage;

    [SerializeField]
    private Enemy _currentEnemy;

    [SerializeField]
    private Enemy[] _enemyTable;

    void Start()
    {
        ReadEnemy(_enemyTable[Random.Range(0, _enemyTable.Length)]);
    }

    void Update()
    {
        if (_currentHp <= 0)
        {
            GameManager.Instance.totalMoney += _currentEnemy.lootAmount; //adds the looting amount of the ressource to the player's money count
            GameManager.Instance.MoneyManager.UpdateMoneyUI();
            ReadEnemy(_enemyTable[Random.Range(0, _enemyTable.Length)]);
        }
    }

    //read a new ressource, refreshing every information onscreen about it
    private void ReadEnemy(Enemy newEnemy)
    {
        _currentEnemy = newEnemy;

        _currentHp = _currentEnemy.hp;
        _maxHp = _currentEnemy.hp;
        _hpImage.fillAmount = 1;


        _hpText.text = _currentEnemy.hp.ToString("000");
        _nameText.text = _currentEnemy.enemyName.ToString();
        _typeText.text = _currentEnemy.type.ToString();
        _rarityText.text = _currentEnemy.rarity.ToString();

        _enemyImage.sprite = _currentEnemy.enemyImage;
    }
}
