using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_ressource", menuName = "Ressource", order = 0)]

public class Ressource : ScriptableObject
{
    public string ressourceName;
    public int hp;
    public RessourceType type;
    public Rarity rarity;
    public Sprite ressourceImage;
}
