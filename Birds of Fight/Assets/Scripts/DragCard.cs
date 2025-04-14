using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform rectTransform;
    Canvas canvas;
    CanvasGroup canvasGroup;
    GameManager gameManager;
    GameObject playerSelectedCard;
    public Transform parentToReturnTo = null;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        gameManager = FindObjectOfType<GameManager>();
        playerSelectedCard = gameManager.playerSelectedCard;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        canvasGroup.blocksRaycasts = true;

        if (parentToReturnTo == playerSelectedCard.transform)
        {
            DisplayCard opponentCard = gameManager.GetOpponentCard();
            DisplayCard playerCard = gameManager.GetPlayerCard();
            gameManager.CompareCards(playerCard.actionCard, opponentCard.actionCard);
        }
    }
}
