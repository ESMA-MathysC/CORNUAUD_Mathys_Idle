using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPrices : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _priceWand1Text;
    [SerializeField]
    private TextMeshProUGUI _priceWand2Text;
    [SerializeField]
    private TextMeshProUGUI _priceWand3Text;

    [SerializeField]
    private TextMeshProUGUI _priceSpell1Text;
    [SerializeField]
    private TextMeshProUGUI _priceSpell2Text;
    [SerializeField]
    private TextMeshProUGUI _priceSpell3Text;

    [SerializeField]
    private TextMeshProUGUI _pricePotion1Text;
    [SerializeField]
    private TextMeshProUGUI _pricePotion2Text;
    [SerializeField]
    private TextMeshProUGUI _pricePotion3Text;

    private void Start()
    {
        UpdatePriceWand1UI();
        UpdatePriceWand2UI();
        UpdatePriceWand3UI();

        UpdatePriceSpell1UI();
        UpdatePriceSpell2UI();
        UpdatePriceSpell3UI();
    }


    public void UpdatePriceWand1UI()
    {
        _priceWand1Text.text = GameManager.Instance.wandUpgrades.wand1Cost.ToString();
    }

    public void UpdatePriceWand2UI()
    {
        _priceWand2Text.text = GameManager.Instance.wandUpgrades.wand2Cost.ToString();
    }

    public void UpdatePriceWand3UI()
    {
        _priceWand3Text.text = GameManager.Instance.wandUpgrades.wand3Cost.ToString();
    }

    public void UpdatePriceSpell1UI()
    {
        _priceSpell1Text.text = GameManager.Instance.spellsUpgrades.spell1Cost.ToString();
    }
    public void UpdatePriceSpell2UI()
    {
        _priceSpell2Text.text = GameManager.Instance.spellsUpgrades.spell2Cost.ToString();
    }
    public void UpdatePriceSpell3UI()
    {
        _priceSpell3Text.text = GameManager.Instance.spellsUpgrades.spell3Cost.ToString();
    }

}
