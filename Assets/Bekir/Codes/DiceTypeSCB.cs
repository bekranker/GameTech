using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


[CreateAssetMenu(menuName = "DiceTypes", fileName = "CreateDiceType", order = 1)]
public class DiceTypeSCB : ScriptableObject
{
    public string DiceType;
    public Sprite DiceSprite;
}