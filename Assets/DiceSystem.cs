using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class DiceSystem : MonoBehaviour
{
    [SerializeField] private List<Dice> _dices;
    [SerializeField] private List<TMP_Text> _diceTexts;
    public int SpawnedDiceCount;
    public int Max, Min;
    public float Movement, Combat, Defend;
    public bool CanRoll, DidRoll;

    public void SetConfigs()
    {
        for (int i = 0; i < _dices.Count; i++)
        {
            if (_dices[i].DiceType.TypeOfDice == TypeOfDices.Movement)
            {
                Movement = _dices[i].DiceNumber;
            }
            if (_dices[i].DiceType.TypeOfDice == TypeOfDices.Combnat)
            {
                Combat = _dices[i].DiceNumber;
            }
            if (_dices[i].DiceType.TypeOfDice == TypeOfDices.Defence)
            {
                Defend = _dices[i].DiceNumber;
            }
        }
    }

    public void RollDice()
    {
        if(!CanRoll) return;
        for (int i = 0; i < _dices.Count; i++)
        {
            _dices[i].RollMe();           
        }
        CanRoll = false;
    }
    public void UpdateDiceTexts(int index, int diceNumber)
    {
        _diceTexts[index].text = diceNumber.ToString();
    }
}