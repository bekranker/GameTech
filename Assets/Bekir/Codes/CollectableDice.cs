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

    public DiceTypeSCB DiceType{get; set;}
    private Player _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void HoldMeBegin()
    {
        transform.DOPunchScale(Vector3.one * _punchForceDT, _punchSpeedDT);
    }
}