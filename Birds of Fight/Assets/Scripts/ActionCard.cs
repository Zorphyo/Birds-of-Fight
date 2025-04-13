using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[CreateAssetMenu(fileName = "New Card", menuName = "Action Card")]
public class ActionCard : ScriptableObject
{
    public string cardName;
    public string cardDescription;
    public string moveType;
    public string bodyPart;
    public Sprite cardImage;

    public ActionCard()
    {

    }

}
