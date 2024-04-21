using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour, IMoveable, IDamagable
{
    [SerializeField] private float _moveSpeed = 10.0f;
    public List<CollectableDice> CapturedDices = new List<CollectableDice>();
    [SerializeField] private SpriteRenderer _sp;
    [SerializeField] private Slider HealthBar;
    [SerializeField] public Slider ShieldBar;
    [SerializeField] private GameObject _damageParticle, _shieldDamageParticle;
    [SerializeField] private GameObject _restartScreen;
    public float Health;
    public float Shield;
    public bool CanWalk;

    void Start()
    {
        ShieldBar.gameObject.SetActive(false);
    }
    public void Move(Vector2 toGo)
    {
        if(!CanWalk) return;
        transform.DOMove(toGo, _moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            GetComponent<Animator>().Play("Idle");
        });
        if (transform.position.x > toGo.x)
        {
            _sp.flipX = true;
        }
        else
        {
            _sp.flipX = false;
        }
        GetComponent<Animator>().Play("Walk");
    }

    void Update()
    {
        HealthBar.value = Health;
        ShieldBar.value = Shield;
        if (Shield > 0)
        {
            ShieldBar.gameObject.SetActive(true);
        }
        else
        {
            ShieldBar.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        if (Shield <= 0)
        {
            if (Health - damage <= 0)
            {
                //Die
                _restartScreen.SetActive(true);
                return;
            }
            Instantiate(_damageParticle, transform.position, Quaternion.identity);
            Health -= damage;
        }
        else
        {
            Instantiate(_shieldDamageParticle, transform.position, Quaternion.identity);
            Shield -= damage;
        }
        GetComponent<Animator>().Play("Hit");
    }
    public void SelectMe()
    {
        DOTween.Kill(_sp);
        _sp.transform.DOPunchScale(Vector3.one * 0.5f, 0.3f);
    }
}