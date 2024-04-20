using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


[CreateAssetMenu(menuName = "DiceTypes", fileName = "CreateDiceType", order = 1)]
public class DiceTypeSCB : ScriptableObject
{
    public Sprite DiceSprite;
    public int DiceHealth;
    public TypeOfDices TypeOfDice;
}
public enum TypeOfDices
{
    Movement,
    Combnat,
    Defence
}