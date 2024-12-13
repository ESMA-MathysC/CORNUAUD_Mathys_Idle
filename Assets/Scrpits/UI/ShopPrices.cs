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
        UpdatePriceWand1();
        UpdatePriceWand2();
    }


    public void UpdatePriceWand1()
    {
        _priceWand1Text.text = GameManager.Instance.wandUpgrades.wand1Cost.ToString("0000");
    }

    public void UpdatePriceWand2()
    {
        _priceWand2Text.text = GameManager.Instance.wandUpgrades.wand2Cost.ToString("0000");
    }

}
