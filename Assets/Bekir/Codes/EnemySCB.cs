using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemySCB : ScriptableObject
{
    public float Health;
    public float StepCount;
    public Sprite Sprite;
    public float Damage;
    public float Speed;
}