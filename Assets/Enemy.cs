using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour, IMoveable, IDamagable
{

    [SerializeField] private float _moveSpeed = 10.0f;
    public float Health;


    public void Move(Vector2 toGo)
    {
        
    }

    public void TakeDamage(float damage)
    {
        
    }
}