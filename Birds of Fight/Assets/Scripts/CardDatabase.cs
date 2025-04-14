using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton that holds all of the Action Card Scriptable Objects
public class CardDatabase : MonoBehaviour
{
    [SerializeField]
    public List<ActionCard> cardList = new List<ActionCard>();
}
