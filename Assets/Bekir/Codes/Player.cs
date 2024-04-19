using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMoveable, IDamagable
{
    [SerializeField] private float _moveSpeed = 10.0f;
    



    public void Move(Vector2 toGo)
    {

    }

    public void TakeDamage(float damage)
    {
    }
}