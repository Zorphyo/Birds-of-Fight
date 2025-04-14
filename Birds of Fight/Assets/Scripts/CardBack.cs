using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Small script to control whether the back of a card is showing or not (the card is flipped over). This is mainly for opponent cards.
public class CardBack : MonoBehaviour
{
    public GameObject cardBack; //The UI Card GameObject. Has the DisplayCard component attached, which controls how the card is displayed. 

    // Update is called once per frame
    void Update()
    {
        if (DisplayCard.staticCardBack == true) //DisplayCard has a static bool that controls whether the back of the card should be displayed or not
        {
            cardBack.SetActive(true);
        }

        else
        {
            cardBack.SetActive(false);
        }
    }
}
