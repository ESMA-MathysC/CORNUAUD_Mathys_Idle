using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerAttack playerClick;
    public EnemySpawner enemy;
    public WandUpgrades wandUpgrades;
    public ShopPrices shopPrices;
    public MoneyManager moneyManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
