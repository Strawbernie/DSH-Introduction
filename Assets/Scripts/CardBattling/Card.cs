using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public int cardID;
    public string cardName;
    public string cardDescription;

    public Sprite cardSprite;
    public int mentalCost;
    public int damage;
}
