using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHolder : MonoBehaviour
{
    public CollectableDice CollectedDice;
    public int DiceHealth;



    public void ChangeDice(CollectableDice dice)
    {
        CollectedDice = dice;
        DiceHealth = dice.DiceType.DiceHealth;
    }
}
