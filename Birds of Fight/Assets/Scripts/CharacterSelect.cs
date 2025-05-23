using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    GameManager gameManager;
    CardDatabase cardDatabase;

    public GameObject playerHand;
    public GameObject opponentHand;

    public UnityEngine.UI.Image playerCharacterCard;
    public UnityEngine.UI.Image opponentCharacterCard;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        cardDatabase = FindObjectOfType<CardDatabase>();
    }

    public void EagleSelect()
    {
        gameManager.playerCharacter = cardDatabase.characterList[0];
        RandomOpponent();

        playerCharacterCard.sprite = gameManager.playerCharacter.cardImage;
        opponentCharacterCard.sprite = gameManager.opponentCharacter.cardImage;

        PlayerDeck playerDeck = playerHand.GetComponent<PlayerDeck>();
        PlayerDeck opponentDeck = opponentHand.GetComponent<PlayerDeck>();

        playerDeck.StartGame();
        opponentDeck.StartGame();

        gameObject.SetActive(false);
               
    }

    public void RavenSelect()
    {
        gameManager.playerCharacter = cardDatabase.characterList[1];
        RandomOpponent();

        playerCharacterCard.sprite = gameManager.playerCharacter.cardImage;
        opponentCharacterCard.sprite = gameManager.opponentCharacter.cardImage;

        PlayerDeck playerDeck = playerHand.GetComponent<PlayerDeck>();
        PlayerDeck opponentDeck = opponentHand.GetComponent<PlayerDeck>();

        playerDeck.StartGame();
        opponentDeck.StartGame();

        gameObject.SetActive(false);
    }

    void RandomOpponent()
    {
        int characterCount = cardDatabase.characterList.Count;
        int randomOpponent = Random.Range(0, characterCount);

        gameManager.opponentCharacter = cardDatabase.characterList[randomOpponent];
    }
}
