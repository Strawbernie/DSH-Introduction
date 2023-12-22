using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public string cardDescription;

    public Sprite cardSprite;

    public int rarity;
    public Color rarity1;
    public int mentalCost;
    public int damage;
    public int block;
    public int doesWeaken;
    public int doesVulnerable;
}
