using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour, IMoveable, IDamagable
{
    [SerializeField] private float _moveSpeed = 10.0f;
    public List<CollectableDice> CapturedDices = new List<CollectableDice>();
    public float Health;



    public void Move(Vector2 toGo)
    {

    }

    public void TakeDamage(float damage)
    {

    }
}