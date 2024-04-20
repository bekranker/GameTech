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
    private Transform _player;
    public bool _arrived;
    private bool MOVE;
    private Vector3 newPoint;
    private float _delayCurrent;
    private float _delay = 1f;


    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _diceSystem = FindAnyObjectByType<DiceSystem>();
        Initialize();
    }
    public bool EnemyAction()
    {
        if (Vector2.Distance(_player.position, transform.position) < 1.5f)
        {
            //attack
            MOVE = false;
        }
        else
        {
            _delayCurrent = _delay;
            MOVE = true;
            var direction = (_player.position - transform.position).normalized;
            newPoint = new Vector3(transform.position.x + (direction.x * _enemySCB.StepCount), transform.position.y + (direction.y * _enemySCB.StepCount), 0);
            return _arrived;
        }
        return _arrived;
    }
    void Update()
    {
        Move(default);
    }
    public void Move(Vector2 toGo)
    {
        if(!MOVE) return;
        Camera.main.GetComponent<CameraFollow>().SetTarget(transform);
        _delayCurrent -= Time.deltaTime;
        if (_delayCurrent <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, newPoint, _enemySCB.Speed * Time.deltaTime);
            if (transform.position == newPoint)
            {
                MOVE = false;
                _arrived = true;
                _delayCurrent = _delay;
            }
        }
        //DOTween.Kill(transform);
        
        //transform.DOMove(newPoint, _enemySCB.Speed).OnComplete(() => MOVE = false);
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
        _moveSpeed = _enemySCB.StepCount;
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