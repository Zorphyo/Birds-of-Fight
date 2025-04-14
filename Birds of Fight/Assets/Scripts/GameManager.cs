using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject opponentHand;
    public GameObject playerHand;
    public GameObject opponentSelectedCard;
    public GameObject playerSelectedCard;
    public TextMeshProUGUI resultText;
    public GameObject resultsScreen;
    CursorControl cursorControl;

    public static bool playerLostRound = false;
    public static bool playerWonRound = false;
    public static bool tie = false;
    public static bool playerLostGame = false;

    private void Awake()
    {
        cursorControl = GetComponent<CursorControl>();
    }

    public DisplayCard GetPlayerCard()
    {
        DisplayCard card = playerSelectedCard.transform.GetChild(0).GetComponent<DisplayCard>();

        return card;
    }

    public DisplayCard GetOpponentCard()
    {
        int random = Random.Range(0, opponentHand.transform.childCount);
        Transform card = opponentHand.transform.GetChild(random);
        card.SetParent(opponentSelectedCard.transform);
        DisplayCard cardData = card.gameObject.GetComponent<DisplayCard>();
        cardData.cardBack = false;

        return cardData;
    }

    public void CompareCards(DisplayCard playerCard, DisplayCard opponentCard)
    {
        if (playerCard.actionCard.moveType == opponentCard.actionCard.moveType)
        {
            if (playerCard.actionCard.bodyPart == opponentCard.actionCard.bodyPart)
            {
                StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
                Tie();
            }

            else if ((playerCard.actionCard.bodyPart == "Talon" && opponentCard.actionCard.bodyPart == "Wing") || (playerCard.actionCard.bodyPart == "Wing" && opponentCard.actionCard.bodyPart == "Beak") || (playerCard.actionCard.bodyPart == "Beak" && opponentCard.actionCard.bodyPart == "Talon"))
            {
                StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
                PlayerWonRound();
            }

            else
            {
                StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
                PlayerLostRound();
            }
        }

        else if ((playerCard.actionCard.moveType == "Attack" && opponentCard.actionCard.moveType == "Throw") || (playerCard.actionCard.moveType == "Throw" && opponentCard.actionCard.moveType == "Evade") || (playerCard.actionCard.moveType == "Evade" && opponentCard.actionCard.moveType == "Attack"))
        {
            StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
            PlayerWonRound();
        }

        else 
        {
            StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
            PlayerLostRound();
        }
    }

    void Tie()
    {
        Debug.Log("Tie");
        tie = true;
        cursorControl.UnlockCursor();
    }

    void PlayerWonRound()
    {
        Debug.Log("Player Wins!");
        playerWonRound = true;
        StartCoroutine(OpponentDiscard());
    }

    void PlayerLostRound()
    {
        Debug.Log("Player Loses!");
        playerLostRound = true;
        cursorControl.UnlockCursor();
    }

    IEnumerator RemoveActiveCards(DisplayCard playerCard, DisplayCard opponentCard)
    {
        cursorControl.LockCursor();

        yield return new WaitForSeconds(1);

        Destroy(playerCard.gameObject);
        Destroy(opponentCard.gameObject);

        yield return new WaitForSeconds(2);

        CheckForWinner();
    }

    IEnumerator OpponentDiscard()
    {
        yield return new WaitForSeconds(2);

        int random = Random.Range(0, opponentHand.transform.childCount);
        Transform card = opponentHand.transform.GetChild(random);
        Destroy(card.gameObject);

        cursorControl.UnlockCursor();
        CheckForWinner();
    }

    public void CheckForWinner()
    {
        if (opponentHand.transform.childCount == 0 && playerHand.transform.childCount == 0)
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

        else if (opponentHand.transform.childCount == 0)
        {
            resultText.SetText("You Win!!");
            resultsScreen.SetActive(true);
        }

        else if (playerHand.transform.childCount == 0)
        {
            resultText.SetText("You Lose...");
            resultsScreen.SetActive(true);
        }

        else if (playerLostGame)
        {
            resultText.SetText("You Lose...");
            resultsScreen.SetActive(true);
        }
    }
}