using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject opponentHand;
    public GameObject opponentSelectedCard;
    public GameObject playerSelectedCard;

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

    public void CompareCards(ActionCard playerCard, ActionCard opponentCard)
    {
        if (playerCard.moveType == opponentCard.moveType)
        {
            if (playerCard.bodyPart == opponentCard.bodyPart)
            {
                Tie();
            }

            else if ((playerCard.bodyPart == "Talon" && opponentCard.bodyPart == "Wing") || (playerCard.bodyPart == "Wing" && opponentCard.bodyPart == "Beak") || (playerCard.bodyPart == "Beak" && opponentCard.bodyPart == "Talon"))
            {
                PlayerWonRound();
            }

            else
            {
                PlayerLostRound();
            }
        }

        else if ((playerCard.moveType == "Attack" && opponentCard.moveType == "Throw") || (playerCard.moveType == "Throw" && opponentCard.moveType == "Evade") || (playerCard.moveType == "Evade" && opponentCard.moveType == "Attack"))
        {
            PlayerWonRound();
        }

        else 
        {
            PlayerLostRound();
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
}
