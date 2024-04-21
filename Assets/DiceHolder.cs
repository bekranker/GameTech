using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DiceHolder : MonoBehaviour
{
    public bool Fill;
    public int DiceHealth;
    [SerializeField] public SpriteRenderer _sp;
    [SerializeField] private List<Dice> _dices = new List<Dice>(); // ilk dice Movement, ikinci dice Combnat, ucuncu dice Defence
    public Dice MyDice;
    public bool StarterMovement, StarterCombat, StarterDefence;
    [SerializeField] private DiceSystem _dicesystem;
    [SerializeField] private DiceHit _diceHit;


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
        DiceHealth = MyDice.DiceType.DiceHealth;
    }

    public void ChangeDice(CollectableDice dice, Sprite sprite)
    {
        _sp.color = Color.white;
        _sp.sprite = sprite;
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
    public void DecreaseDiceHealth()
    {
        Transform hit = Instantiate(_diceHit, transform.position + Vector3.up, Quaternion.identity).transform;
        hit.SetParent(transform);
        DiceHealth--;
        if (DiceHealth <= 0)
        {
            _dicesystem.DiceCountInHand--;
            MyDice = null;
            _sp.color = Color.black;
            Fill = false;
        }
    }
}