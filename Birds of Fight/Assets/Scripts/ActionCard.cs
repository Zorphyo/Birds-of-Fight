using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

//Scriptable Object for each of the Cards in the game. Each card has a name, description, move type, body part, and image

[CreateAssetMenu(fileName = "New Card", menuName = "Action Card")]
public class ActionCard : ScriptableObject
{
    public string cardName;
    public string cardDescription;
    public string moveType;
    public string bodyPart;
    public Sprite cardImage;
}
