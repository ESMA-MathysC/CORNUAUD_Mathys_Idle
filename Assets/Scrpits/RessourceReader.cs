using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RessourceReader : MonoBehaviour
{
    private int _currentHp;
    [SerializeField]
    private TextMeshProUGUI _hpText, _nameText, _typeText, _rarityText, _ressourceText;
    [SerializeField]
    private Image _ressourceImage;

    [SerializeField]
    private Ressource _currentRessource;

    [SerializeField]
    private Ressource[] _ressourceTable;

    public int totalRessource = 0;

    void Start()
    {
        ReadRessource(_ressourceTable[Random.Range(0, _ressourceTable.Length)]);
    }

    public void PlayerAttack()
    {
        _currentHp -= 1;
        _hpText.text = _currentHp.ToString("000");
        if ( _currentHp <= 0)
        {
            totalRessource += _currentRessource.lootAmount;
            _ressourceText.text = totalRessource.ToString("000");
            ReadRessource(_ressourceTable[Random.Range(0, _ressourceTable.Length)]);
        }
    }

    private void ReadRessource(Ressource newRessource)
    {
        _currentRessource = newRessource;

        _currentHp = _currentRessource.hp;

        _hpText.text = _currentRessource.hp.ToString("000");
        _nameText.text = _currentRessource.ressourceName.ToString();
        _typeText.text = _currentRessource.type.ToString();
        _rarityText.text = _currentRessource.rarity.ToString();

        _ressourceImage.sprite = _currentRessource.ressourceImage;
    }
}