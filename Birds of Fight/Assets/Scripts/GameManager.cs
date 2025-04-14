using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject opponentHand;
    public GameObject opponentSelectedCard;
    public GameObject playerSelectedCard;
    CursorControl cursorControl;

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
                Tie();
                StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
            }

            else if ((playerCard.actionCard.bodyPart == "Talon" && opponentCard.actionCard.bodyPart == "Wing") || (playerCard.actionCard.bodyPart == "Wing" && opponentCard.actionCard.bodyPart == "Beak") || (playerCard.actionCard.bodyPart == "Beak" && opponentCard.actionCard.bodyPart == "Talon"))
            {
                PlayerWonRound();
                StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
            }

            else
            {
                PlayerLostRound();
                StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
            }
        }

        else if ((playerCard.actionCard.moveType == "Attack" && opponentCard.actionCard.moveType == "Throw") || (playerCard.actionCard.moveType == "Throw" && opponentCard.actionCard.moveType == "Evade") || (playerCard.actionCard.moveType == "Evade" && opponentCard.actionCard.moveType == "Attack"))
        {
            PlayerWonRound();
            StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
        }

        else 
        {
            PlayerLostRound();
            StartCoroutine(RemoveActiveCards(playerCard, opponentCard));
        }
    }

    void Tie()
    {
        Debug.Log("Tie");
    }

    void PlayerWonRound()
    {
        Debug.Log("Player Wins!");
    }

    void PlayerLostRound()
    {
        Debug.Log("Player Loses!");
    }

    IEnumerator RemoveActiveCards(DisplayCard playerCard, DisplayCard opponentCard)
    {
        cursorControl.LockCursor();

        yield return new WaitForSeconds(1);

        Destroy(playerCard.gameObject);
        Destroy(opponentCard.gameObject);

        cursorControl.UnlockCursor();
    }
}
