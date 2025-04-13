using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    int randomCard;

    public GameObject cardPrefab;
    public RectTransform deckPanel;

    // Start is called before the first frame update
    void Start()
    {
        CardDatabase cardDatabase = FindObjectOfType<CardDatabase>();

        for (int i = 0; i < 5; i ++)
        {
            randomCard = Random.Range(0,2);

            GameObject newCard = Instantiate(cardPrefab, deckPanel);
            DisplayCard cardData = newCard.GetComponent<DisplayCard>();
            cardData.actionCard = cardDatabase.cardList[randomCard];
        }

        for (int i = 0; i < 5; i ++)
        {
            randomCard = Random.Range(3,5);

            GameObject newCard = Instantiate(cardPrefab, deckPanel);
            DisplayCard cardData = newCard.GetComponent<DisplayCard>();
            cardData.actionCard = cardDatabase.cardList[randomCard];
        }

        for (int i = 0; i < 5; i ++)
        {
            randomCard = Random.Range(8,10);

            GameObject newCard = Instantiate(cardPrefab, deckPanel);
            DisplayCard cardData = newCard.GetComponent<DisplayCard>();
            cardData.actionCard = cardDatabase.cardList[randomCard];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
