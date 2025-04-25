using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Card")]
public class CharacterCard : ScriptableObject
{
    public int attackCardCount;
    public int throwCardCount;
    public int evadeCardCount;
    public int specialCardCount;
    
    public ActionCard specialCardProperties;
}
