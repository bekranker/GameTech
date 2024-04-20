using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHolder : MonoBehaviour
{
    public bool Fill;
    public int DiceHealth;
    [SerializeField] private SpriteRenderer _sp;
    [SerializeField] private List<Dice> _dices = new List<Dice>(); // ilk dice Movement, ikinci dice Combnat, ucuncu dice Defence
    [SerializeField] private Dice _myDice;

    public void ChangeDice(CollectableDice dice)
    {
        _sp.sprite = dice.DiceType.DiceSprite;
        Fill = true;
        DiceHealth = dice.DiceType.DiceHealth;
        SetADice(dice.DiceType);
    }
    private void SetADice(DiceTypeSCB diceTypeSCB)
    {
        switch (diceTypeSCB.TypeOfDice)
        {
            case TypeOfDices.Movement:
                _myDice = _dices[0];
                break;
            case TypeOfDices.Combnat:
                _myDice = _dices[1];
                break;
            case TypeOfDices.Defence:
                _myDice = _dices[2];
                break;
            default:
                break;
        }
    }
}