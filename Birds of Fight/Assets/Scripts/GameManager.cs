using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//This is where all the game operations happen
public class GameManager : MonoBehaviour
{
    public GameObject opponentHand;
    public GameObject playerHand;
    public GameObject opponentSelectedCard;
    public GameObject playerSelectedCard;
    public TextMeshProUGUI resultText;
    public GameObject resultsScreen;
    public TextMeshProUGUI instructionsText;
    public TextMeshProUGUI discardText;
    CursorControl cursorControl;

    public static bool playerLostRound = false;
    public static bool playerWonRound = false;
    public static bool tie = false;
    public static bool playerLostGame = false;

    private void Awake()
    {
        cursorControl = GetComponent<CursorControl>();
    }

    public DisplayCard GetPlayerCard() //gets the card the player recently played for this round
    {
        DisplayCard card = playerSelectedCard.transform.GetChild(0).GetComponent<DisplayCard>();

        return card;
    }

    public DisplayCard GetOpponentCard() //gets a random card from the opponent for them to play this round
    {
        int random = Random.Range(0, opponentHand.transform.childCount);
        Transform card = opponentHand.transform.GetChild(random);
        card.SetParent(opponentSelectedCard.transform);
        DisplayCard cardData = card.gameObject.GetComponent<DisplayCard>();
        cardData.FlipCard();

        return cardData;
    }

    public void CompareCards(DisplayCard playerCard, DisplayCard opponentCard) //logic to see who won the round based on the cards played. Follow up actions will occur as necessary
    {
        if (playerCard.actionCard.attackType == opponentCard.actionCard.attackType) //Tie 1
        {
            if (playerCard.actionCard.bodyPart == opponentCard.actionCard.bodyPart) //Tie 2
            {
                StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
                Tie();
            }

            else if ((playerCard.actionCard.bodyPart == ActionCard.BodyPart.Talon && opponentCard.actionCard.bodyPart == ActionCard.BodyPart.Wing) || 
            (playerCard.actionCard.bodyPart == ActionCard.BodyPart.Wing && opponentCard.actionCard.bodyPart == ActionCard.BodyPart.Beak) || 
            (playerCard.actionCard.bodyPart == ActionCard.BodyPart.Beak && opponentCard.actionCard.bodyPart == ActionCard.BodyPart.Talon))
            {
                StartCoroutine(RemoveActiveCards(playerCard, opponentCard)); //Player won based on body parts
                PlayerWonRound();
            }

            else
            {
                StartCoroutine(RemoveActiveCards(playerCard, opponentCard)); //Player lost based on body parts
                PlayerLostRound();
            }
        }

        //Player won based on attack type
        else if ((playerCard.actionCard.attackType == ActionCard.AttackType.Attack && opponentCard.actionCard.attackType == ActionCard.AttackType.Throw) || 
        (playerCard.actionCard.attackType == ActionCard.AttackType.Throw && opponentCard.actionCard.attackType == ActionCard.AttackType.Evade) || 
        (playerCard.actionCard.attackType == ActionCard.AttackType.Evade && opponentCard.actionCard.attackType == ActionCard.AttackType.Attack))
        {
            StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
            PlayerWonRound();
        }

        //Player lost based on attack type
        else 
        {
            StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
            PlayerLostRound();
        }
    }

    void Tie() //Round is a tie, both players discard played card
    {
        instructionsText.SetText("Tie!");
        tie = true;
    }

    void PlayerWonRound() //Player won the round, the opponent discards an extra card at random
    {
        instructionsText.SetText("Player Wins!");
        playerWonRound = true;
        StartCoroutine(OpponentDiscard());
    }

    void PlayerLostRound() //Player lost the round, they must choose an extra card to discard
    {
        instructionsText.SetText("Player Loses!");
        playerLostRound = true;
        discardText.gameObject.SetActive(true);
    }

    IEnumerator RemoveActiveCards(DisplayCard playerCard, DisplayCard opponentCard) //Removes the cards that were played by the player and opponent for that round after the winner is decided
    {
        cursorControl.LockCursor();

        yield return new WaitForSeconds(1);

        Destroy(playerCard.gameObject);
        Destroy(opponentCard.gameObject);

        yield return new WaitForSeconds(1);

        instructionsText.SetText("Select Your Card");
        cursorControl.UnlockCursor();
        CheckForWinner();
    }

    IEnumerator OpponentDiscard() //Logic for removing a random card from the opponent
    {
        yield return new WaitForSeconds(2);

        if (opponentHand.transform.childCount != 0)
        {
            int random = Random.Range(0, opponentHand.transform.childCount);
            Transform card = opponentHand.transform.GetChild(random);
            Destroy(card.gameObject);
        }

        cursorControl.UnlockCursor();
        CheckForWinner();
    }

    public void CheckForWinner() //Function that checks to see if either player has run out of cards, meaning they lost the game, and pulls up the results screen if a winner is decided
    {
        if (opponentHand.transform.childCount == 0 && playerHand.transform.childCount == 0) //Player and opponent reached zero cards at the same time
        {
            if (tie)
            {
                resultText.SetText("It's a tie!");
            }

            else if (playerWonRound)
            {
                resultText.SetText("You Win!!");
            }

            else if (playerLostRound)
            {
                resultText.SetText("You Lose...");
            }

            resultsScreen.SetActive(true);
        }

        else if (opponentHand.transform.childCount == 0) //Opponent lost
        {
            resultText.SetText("You Win!!");
            resultsScreen.SetActive(true);
        }

        else if (playerHand.transform.childCount == 0) //Player lost
        {
            resultText.SetText("You Lose...");
            resultsScreen.SetActive(true);
        }

        else if (playerLostGame) //Player lost after discarding their last card
        {
            resultText.SetText("You Lose...");
            resultsScreen.SetActive(true);
        }
    }
}