using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour, IMoveable, IDamagable
{
    [SerializeField] private EnemySCB _enemySCB;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private Animator _animation;
    [SerializeField] private CollectableDice _dice;
    [SerializeField] private List<DiceTypeSCB> _diceTypes;
    [SerializeField] private DiceSystem _diceSystem;
    [SerializeField] private SpriteRenderer _sp;
    [SerializeField] private Color _hitColor;
    public float Health;



    void Start()
    {
        _diceSystem = FindAnyObjectByType<DiceSystem>();
        Initialize();
    }

    public void Move(Vector2 toGo)
    {
        
    }
    
    public void TakeDamage(float damage)
    {
        if (Health - damage <= 0)
        {
            Death();
            return;
        }
        Health -= damage;
        HitEffect();
    }

    public void Initialize()
    {
        _sp.sprite = _enemySCB.Sprite;
        Health = _enemySCB.Health;
        _moveSpeed = _enemySCB.MoveSpeed;
        _damage = _enemySCB.Damage;
    }
    private void Death()
    {
        if (_diceSystem.SpawnedDiceCount < _diceSystem.Max)
        {
            _diceSystem.SpawnedDiceCount++;
            CollectableDice spawnedDiece = Instantiate(_dice, transform.position, Quaternion.identity);
            spawnedDiece.DiceType = _diceTypes[Random.Range(0, _diceTypes.Count)];
        }
        DeathEffect();
    }
    private void HitEffect()
    {
        DOTween.Kill(_sp);
        _sp.color = _hitColor;
        _sp.DOColor(Color.white, 0.25f);
    }
    private void DeathEffect()
    {
        //_animation.SetTrigger("Death");
        Destroy(gameObject);
    }
}