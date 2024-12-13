using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_enemy", menuName = "Enemy", order = 0)]

public class Enemy : ScriptableObject
{
    public string enemyName;
    public int hp;
    public EnemyType type;
    public Rarity rarity;
    public int lootAmount;
    public Sprite enemyImage;
}
