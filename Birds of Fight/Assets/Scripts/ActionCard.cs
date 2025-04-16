using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

//Scriptable Object for each of the Cards in the game. Each card has a name, description, move type, body part, and image

[CreateAssetMenu(fileName = "New Card", menuName = "Action Card")]
public class ActionCard : ScriptableObject
{
    public enum AttackType
    {
        Attack = 1,
        Throw,
        Evade
    };

    public enum BodyPart 
    {
        Talon = 1,
        Wing,
        Beak
    };

    public string cardName;
    public string cardDescription;
    public AttackType attackType;
    public BodyPart bodyPart;
    public Sprite cardImage;
}
