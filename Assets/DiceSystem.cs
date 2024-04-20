using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class DiceSystem : MonoBehaviour
{
    [SerializeField] private List<DiceHolder> _dices;
    [SerializeField] private List<TMP_Text> _diceTexts;
    public int SpawnedDiceCount;
    public int Max, Min;
    public float Movement, Combat, Defend;
    public bool CanRoll, DidRoll;
    public int RolledDiceCount, DiceCountInHand;
    private bool _canSetConfigs;

    void Start()
    {
        _canSetConfigs = true;
    }

    public void SetConfigs()
    {
        for (int i = 0; i < _dices.Count; i++)
        {
            if (_dices[i] != null && _dices[i].MyDice != null)
            {
                if (_dices[i].MyDice.DiceType.TypeOfDice == TypeOfDices.Movement)
                {
                    print(_dices[i].MyDice.DiceNumber);
                    Movement += _dices[i].MyDice.DiceNumber;
                }
                else if (_dices[i].MyDice.DiceType.TypeOfDice == TypeOfDices.Combnat)
                {
                    print(_dices[i].MyDice.DiceNumber);
                    Combat += _dices[i].MyDice.DiceNumber;
                }
                else if (_dices[i].MyDice.DiceType.TypeOfDice == TypeOfDices.Defence)
                {
                    print(_dices[i].MyDice.DiceNumber);
                    Defend += _dices[i].MyDice.DiceNumber;
                }
            }
        }
    }
    void Update()
    {
        if (DidRoll && RolledDiceCount == DiceCountInHand)
        {
            if (_canSetConfigs)
            {
                SetConfigs();
                _canSetConfigs = false;
            }
        }
    }
    public void RollDice()
    {
        if(!CanRoll) return;
        RolledDiceCount = 0;
        Movement = 0;
        Combat = 0;
        Defend = 0;
        for (int i = 0; i < _dices.Count; i++)
        {
            if (_dices[i] != null && _dices[i].MyDice != null)
                _dices[i].MyDice.RollMe();
        }
        CanRoll = false;
    }
    public void UpdateDiceTexts(int index, int diceNumber)
    {
        _diceTexts[index].text = diceNumber.ToString();
    }
}