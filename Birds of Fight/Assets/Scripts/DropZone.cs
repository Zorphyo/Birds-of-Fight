using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//When the card is dropped, if it is a valid place to drop the card, make that spot the card's new parent and set it's transform.
public class DropZone : MonoBehaviour, IDropHandler //IPointerEnterHandler, IPointerExitHandler
{
    /*public void OnPointerEnter(PointerEventData eventData)
    {

    }*/

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<DragCard>().parentToReturnTo = this.transform;
        }
    }

    /*public void OnPointerExit(PointerEventData eventData)
    {

    }*/
}
