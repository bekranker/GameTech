using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHolder : MonoBehaviour
{
    public CollectableDice CollectedDice;
    public int DiceHealth;
    [SerializeField] private SpriteRenderer _sp;



    public void ChangeDice(CollectableDice dice)
    {
        _sp.sprite = dice.DiceType.DiceSprite;
        CollectedDice = dice;
        DiceHealth = dice.DiceType.DiceHealth;
        Destroy(dice.gameObject);
    }
}
