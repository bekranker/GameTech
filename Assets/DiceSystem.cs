using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class DiceSystem : MonoBehaviour
{
    [SerializeField] private List<Dice> _dices;


    


    public void RollDice()
    {
        for (int i = 0; i < _dices.Count; i++)
        {
            _dices[i].RollMe();            
        }
    }
}