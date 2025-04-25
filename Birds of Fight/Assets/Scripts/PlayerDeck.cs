using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that populates the hands for both the player and the opponent with cards that have scriptable objects tied to them
public class PlayerDeck : MonoBehaviour
{
    int randomCard;

    public GameObject cardPrefab;
    public bool opponentHand;
    public RectTransform deckPanel;

    GameManager gameManager;
    CardDatabase cardDatabase;
    CursorControl cursorControl;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        CharacterCard playerCharacter = gameManager.playerCharacter;
        CharacterCard opponentCharacter = gameManager.opponentCharacter;

        cardDatabase = FindObjectOfType<CardDatabase>();

        cursorControl = FindObjectOfType<CursorControl>();
        cursorControl.LockCursor(); //Lock mouse input until all cards are drawn

        if (opponentHand)
        {
            StartCoroutine(DrawCards(opponentCharacter.attackCardCount, opponentCharacter.throwCardCount, opponentCharacter.evadeCardCount, opponentCharacter.specialCardCount));
        }

        else
        {
            StartCoroutine(DrawCards(playerCharacter.attackCardCount, playerCharacter.throwCardCount, playerCharacter.evadeCardCount, playerCharacter.specialCardCount));
        }
    }

    IEnumerator DrawCards(int attackCount, int throwCount, int evadeCount, int specialCount) //draws five cards of each attack type randomly, and flips the cards over if they are opponent cards
    {
        for (int i = 0; i < attackCount; i ++) //Attack Cards
        {
            randomCard = Random.Range(0,3);

            yield return new WaitForSeconds(0.25f);

            GameObject newCard = Instantiate(cardPrefab, deckPanel);
            DisplayCard cardData = newCard.GetComponent<DisplayCard>();
            cardData.actionCard = cardDatabase.cardList[randomCard];

            if (!opponentHand)
            {
                cardData.FlipCard();
            }
        }

        for (int i = 0; i < throwCount; i++) //Throw Cards
        {
            randomCard = Random.Range(3,6);

            yield return new WaitForSeconds(0.25f);

            GameObject newCard = Instantiate(cardPrefab, deckPanel);
            DisplayCard cardData = newCard.GetComponent<DisplayCard>();
            cardData.actionCard = cardDatabase.cardList[randomCard];

            if (!opponentHand)
            {
                cardData.FlipCard();
            }
        }

        for (int i = 0; i < evadeCount; i++) //Evade cards
        {
            randomCard = Random.Range(7,10);

            yield return new WaitForSeconds(0.25f);

            GameObject newCard = Instantiate(cardPrefab, deckPanel);
            DisplayCard cardData = newCard.GetComponent<DisplayCard>();
            cardData.actionCard = cardDatabase.cardList[randomCard];

            if (!opponentHand)
            {
                cardData.FlipCard();
            }
        }

        for (int i = 0; i < specialCount; i++) //Evade cards
        {
            yield return new WaitForSeconds(0.25f);

            GameObject newCard = Instantiate(cardPrefab, deckPanel);
            DisplayCard cardData = newCard.GetComponent<DisplayCard>();
            cardData.actionCard = cardDatabase.cardList[6];

            if (!opponentHand)
            {
                cardData.FlipCard();
            }
        }

        yield return new WaitForSeconds(0.5f);

        gameManager.instructionsText.SetText("Select Your Card");
        cursorControl.UnlockCursor(); //After cards have been drawn, the player can play the game
    }
}
