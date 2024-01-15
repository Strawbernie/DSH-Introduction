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
    public SatisfactionBar satisfactionBar;
    public int currentHealth = 500;

    public TextMeshProUGUI deckSizeText;
    public TextMeshProUGUI discardSizeText;
    private void Start()
    {
        {
            satisfactionBar.SetMaxHealth(1000);
            satisfactionBar.SetHealth(currentHealth);
        }
    }
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
    public void ApplyEffect(int ID,Card card)
    {
        switch (ID)
        {
            case 0:
                if (satisfactionBar.Type == card.Type)
                {
                    currentHealth +=(50*2);
                }
                else
                {
                    currentHealth +=50;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 1:
                if (satisfactionBar.Type == card.Type)
                {
                    currentHealth +=(60 * 2);
                }
                else
                {
                    currentHealth +=40;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 2:
                if (satisfactionBar.Type == card.Type)
                {
                    currentHealth +=(70 * 2);
                }
                else
                {
                    currentHealth +=30;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 3:
                if (satisfactionBar.Type == card.Type)
                {
                    currentHealth +=(80 * 2);
                }
                else
                {
                    currentHealth +=20;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
            case 4:
                if (satisfactionBar.Type == card.Type)
                {
                    currentHealth +=(90 * 2);
                }
                else
                {
                    currentHealth +=10;
                }
                satisfactionBar.SetHealth(currentHealth);
                break;
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
