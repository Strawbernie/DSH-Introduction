using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Card card;

	public Text nameText;
	public Text descriptionText;

	public Image artworkImage;
	public Image rarity;

	public Text mentalText;
	public Text attackText;
	public Text blockText;

	void Start () {
		nameText.text = card.cardName;
		descriptionText.text = card.cardDescription;

		artworkImage.sprite = card.cardSprite;

		mentalText.text = card.mentalCost.ToString();
		attackText.text = card.damage.ToString();
	}
	
}
