using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

//Script that shows how a Card in the game is displayed. It gets all of its information from the Action Card Scriptable Object associated with it.
public class DisplayCard : MonoBehaviour
{
    public ActionCard actionCard; //Scriptable Object

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public UnityEngine.UI.Image cardImage;

    public bool isFlipped = false;
    public GameObject cardBack;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = actionCard.cardName; //All this info comes from the scriptable object, just updating the UI elements with that info.
        descriptionText.text = actionCard.cardDescription;
        cardImage.sprite = actionCard.cardImage;
    }

    public void FlipCard()
    {
        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false);
        }

        else 
        {
            cardBack.SetActive(true);
        }
    }
}
