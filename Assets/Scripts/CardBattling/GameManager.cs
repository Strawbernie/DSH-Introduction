using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
public List<Cards> deck = new List<Cards>();
    public List<Cards> discardPile = new List<Cards>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    public TextMeshProUGUI deckSizeText;
    public TextMeshProUGUI discardSizeText;
    public void DrawCard()
    {
        if(deck.Count >= 1){
            Cards randCard = deck[Random.Range(0,deck.Count)];

            for (int i =0; i<availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i])
                {
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex= i;

                    randCard.transform.position = cardSlots[i].position;
                    randCard.hasBeenPlayed = false;

                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
    }
    public void Shuffle()
    {
        if(discardPile.Count >= 1)
        {
            foreach(Cards card in discardPile){
                deck.Add(card);
            }
            GameObject[] cardsPlayed = GameObject.FindGameObjectsWithTag("3DCard");
            foreach(GameObject card in cardsPlayed)
            {
                Destroy(card);
            }
            discardPile.Clear();
        }
    }
    private void Update()
    {
        deckSizeText.text = deck.Count.ToString();
        discardSizeText.text = discardPile.Count.ToString();
    }
}
