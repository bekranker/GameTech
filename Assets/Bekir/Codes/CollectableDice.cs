using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CollectableDice : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    public DiceTypeSCB DiceType;
    private Player _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void Collect()
    {
        transform.DOKill(transform);
        if (_player.CapturedDices.Count >= 3)
        {
            transform.DOShakePosition(0.1f);
            return;
        }
        transform.DOMove(_player.transform.position, _moveSpeed).SetEase(Ease.Linear).OnComplete(() => 
        {
            _player.CapturedDices.Add(this);
        });
    }
}