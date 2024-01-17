using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class Cards : MonoBehaviour
{
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManager gm;
    public GameObject ThreeDCard;
    public Card cardInformation;
    GameObject newCard;
    public GameObject originPoint;
    public bool bigger;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {

    }

    void MoveToDiscardPile()
    {
        gm.discardPile.Add(this);
        gameObject.SetActive(false);
    }
    public void PlayCard()
    {
        if (!hasBeenPlayed&&!gm.cantplay)
        {
            transform.position += Vector3.up * 5;
            hasBeenPlayed = true;
            gm.availableCardSlots[handIndex] = true;
            newCard = Instantiate(ThreeDCard, originPoint.transform.position, Quaternion.identity);
            GameObject child = newCard.transform.Find("Cube").gameObject;
            GameObject canvas = child.transform.Find("Canvas").gameObject;
            GameObject card = canvas.transform.Find("Card").gameObject;
            CardDisplay CD = card.GetComponent<CardDisplay>();
            gm.ApplyEffect(cardInformation.cardID,cardInformation);
            CD.card = cardInformation;
            MoveToDiscardPile();
            gm.SayNextLine();
        }
    }
    public void OnPointerEnter()
    {
        bigger = true;
        transform.localScale += new Vector3(0.0001f, 0.0001f, 0);
    }
    public void OnPointerExit()
    {
        bigger = false;
            transform.localScale -= new Vector3(0.0001f, 0.0001f, 0);
    }
}
