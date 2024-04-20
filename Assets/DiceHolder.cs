using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHolder : MonoBehaviour
{
    public bool Fill;
    public int DiceHealth;
    [SerializeField] public SpriteRenderer _sp;
    [SerializeField] private List<Dice> _dices = new List<Dice>(); // ilk dice Movement, ikinci dice Combnat, ucuncu dice Defence
    public Dice MyDice;
    public bool StarterMovement, StarterCombat, StarterDefence;
    [SerializeField] private DiceSystem _dicesystem;

    void Start()
    {
        if (StarterMovement)
        {
            MyDice = _dices[0];
        }
        if (StarterCombat)
        {
            MyDice = _dices[1];
        }
        if (StarterDefence)
        {
            MyDice = _dices[2];
        }
    }

    public void ChangeDice(CollectableDice dice)
    {
        _sp.sprite = dice.DiceType.DiceSprite;
        if (!Fill)
        {
            _dicesystem.DiceCountInHand++;
        }
        Fill = true;
        DiceHealth = dice.DiceType.DiceHealth;
        dice.gameObject.SetActive(false);
        SetADice(dice.DiceType);
    }
    private void SetADice(DiceTypeSCB diceTypeSCB)
    {
        switch (diceTypeSCB.TypeOfDice)
        {
            case TypeOfDices.Movement:
                MyDice = _dices[0];
                break;
            case TypeOfDices.Combnat:
                MyDice = _dices[1];
                break;
            case TypeOfDices.Defence:
                MyDice = _dices[2];
                break;
            default:
                break;
        }
    }
}