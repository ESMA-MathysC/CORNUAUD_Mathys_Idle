using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RessourceReader : MonoBehaviour
{
    private int _currentHp;
    public int _maxHp;
    [SerializeField]
    private TextMeshProUGUI _hpText, _nameText, _typeText, _rarityText, _ressourceText;
    [SerializeField]
    private Image _ressourceImage;
    [SerializeField]
    private Image _hpImage;

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
        _hpImage.fillAmount = (float)_currentHp / (float)_maxHp;
        if ( _currentHp <= 0)
        {
            totalRessource += _currentRessource.lootAmount; //adds the looting amount of the ressource to the player's money count
            _ressourceText.text = totalRessource.ToString("000");
            ReadRessource(_ressourceTable[Random.Range(0, _ressourceTable.Length)]);
        }
    }

    //read a new ressource, refreshing every information onscreen about it
    private void ReadRessource(Ressource newRessource)
    {
        _currentRessource = newRessource;

        _currentHp = _currentRessource.hp;
        _maxHp = _currentRessource.hp;
        _hpImage.fillAmount = 1;


        _hpText.text = _currentRessource.hp.ToString("000");
        _nameText.text = _currentRessource.ressourceName.ToString();
        _typeText.text = _currentRessource.type.ToString();
        _rarityText.text = _currentRessource.rarity.ToString();

        _ressourceImage.sprite = _currentRessource.ressourceImage;
    }
}