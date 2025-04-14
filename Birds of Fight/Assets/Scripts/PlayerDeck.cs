using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    int randomCard;

    public GameObject cardPrefab;
    public bool opponentHand;
    public RectTransform deckPanel;
    public List<ActionCard> hand = new List<ActionCard>();

    CardDatabase cardDatabase;

    // Start is called before the first frame update
    void Start()
    {
        cardDatabase = FindObjectOfType<CardDatabase>();

        StartCoroutine(DrawCards());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DrawCards()
    {
         for (int i = 0; i < 5; i ++)
        {
            randomCard = Random.Range(0,2);

            yield return new WaitForSeconds(0.25f);

            GameObject newCard = Instantiate(cardPrefab, deckPanel);
            DisplayCard cardData = newCard.GetComponent<DisplayCard>();
            cardData.actionCard = cardDatabase.cardList[randomCard];

            if (!opponentHand)
            {
                cardData.cardBack = false;
            }

            hand.Add(cardData.actionCard);
        }

        for (int i = 0; i < 5; i ++)
        {
            randomCard = Random.Range(3,5);

            yield return new WaitForSeconds(0.25f);

            GameObject newCard = Instantiate(cardPrefab, deckPanel);
            DisplayCard cardData = newCard.GetComponent<DisplayCard>();
            cardData.actionCard = cardDatabase.cardList[randomCard];

            if (!opponentHand)
            {
                cardData.cardBack = false;
            }

            hand.Add(cardDatabase.cardList[randomCard]);
        }

        for (int i = 0; i < 5; i ++)
        {
            randomCard = Random.Range(8,10);

            yield return new WaitForSeconds(0.25f);

            GameObject newCard = Instantiate(cardPrefab, deckPanel);
            DisplayCard cardData = newCard.GetComponent<DisplayCard>();
            cardData.actionCard = cardDatabase.cardList[randomCard];

            if (!opponentHand)
            {
                cardData.cardBack = false;
            }

            hand.Add(cardDatabase.cardList[randomCard]);
        }
    }
}
