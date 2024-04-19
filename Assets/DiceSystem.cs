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


    public void RollDice()
    {
        for (int i = 0; i < _dices.Count; i++)
        {
            _dices[i].RollMe();            
        }
    }
    public void UpdateDiceTexts(int index, int diceNumber)
    {
        _diceTexts[index].text = diceNumber.ToString();
    }
}