using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour, IMoveable, IDamagable
{
    [SerializeField] private float _moveSpeed = 10.0f;
    public List<CollectableDice> CapturedDices = new List<CollectableDice>();
    [SerializeField] private SpriteRenderer _sp;
    public float Health;
    public bool CanWalk;


    public void Move(Vector2 toGo)
    {
        if(!CanWalk) return;
        transform.DOMove(toGo, _moveSpeed).SetEase(Ease.Linear);
    }

    public void TakeDamage(float damage)
    {

    }
    public void SelectMe()
    {
        DOTween.Kill(_sp);
        _sp.transform.DOPunchScale(Vector3.one * 0.5f, 0.3f);
    }
}