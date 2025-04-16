using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Script that controls the behavior of the cards when they are dragged and dropped
public class DragCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    RectTransform rectTransform;
    Canvas canvas;
    CanvasGroup canvasGroup;
    GameManager gameManager;
    GameObject playerSelectedCard;
    public Transform parentToReturnTo = null;

    private void Awake() //grabbing all the components I need
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        gameManager = FindObjectOfType<GameManager>();
        playerSelectedCard = gameManager.playerSelectedCard;
    }

    public void OnBeginDrag(PointerEventData eventData) //when a card is first dragged, it sets the point the card should return to if it is dropped in an invalid spot. Also allows for the seeking of valid spots.
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) //Update card position with mouse position while being dragged
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) //Move card to new playing area, whether that is back to the player's hand or to the playing area. If it is moved to the playing area, opponent plays a card and the winner of the round is determined
    {
        this.transform.SetParent(parentToReturnTo);
        canvasGroup.blocksRaycasts = true;

        if (parentToReturnTo == playerSelectedCard.transform)
        {
            DisplayCard opponentCard = gameManager.GetOpponentCard();
            DisplayCard playerCard = gameManager.GetPlayerCard();
            gameManager.CompareCards(playerCard, opponentCard);
        }
    }

    public void OnPointerDown(PointerEventData eventData) //Added an extra click function for when the player has to choose a card to discard when they lose a round. It will check if the card that was discarded was the last card as well, meaning the player lost
    {
        if (GameManager.playerLostRound == true)
        {
            if (gameManager.playerHand.transform.childCount == 1)
            {
                GameManager.playerLostGame = true;
                gameManager.CheckForWinner();
            }
            
            GameManager.playerLostRound = false;
            gameManager.discardText.gameObject.SetActive(false);
            
            Destroy(this.gameObject);
        }
    }
}
