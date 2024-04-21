using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CollectableDice : MonoBehaviour
{

    [SerializeField] private float _punchForceDT;
    [SerializeField] private float _punchSpeedDT;
    [SerializeField] private Sprite Move, Combat, Defence;
    [SerializeField] public SpriteRenderer _sp;
    public DiceTypeSCB DiceType{get; set;}
    private Player _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(DiceType.TypeOfDice == TypeOfDices.Movement)
            _sp.sprite = Move;
        if(DiceType.TypeOfDice == TypeOfDices.Combnat)
            _sp.sprite = Combat;
        if(DiceType.TypeOfDice == TypeOfDices.Defence)
            _sp.sprite = Defence;

    }

    public void HoldMeBegin()
    {
        transform.DOPunchScale(Vector3.one * _punchForceDT, _punchSpeedDT);
    }
}