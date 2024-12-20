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

}
