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
    [SerializeField] private Slider ShieldBar;

    public float Health;
    public float Shield;
    public bool CanWalk;


    public void Move(Vector2 toGo)
    {
        if(!CanWalk) return;
        transform.DOMove(toGo, _moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            GetComponent<Animator>().Play("Idle");
        });
        GetComponent<Animator>().Play("Walk");
    }

    void Update()
    {
        HealthBar.value = Health;
        if (Shield > 0)
        {
            ShieldBar.enabled = true;
            ShieldBar.value = Shield;
        }
    }

    public void TakeDamage(float damage)
    {
        if (Shield <= 0)
        {
            if (Health - damage <= 0)
            {
                //Die
                return;
            }
            Health -= damage;
        }
        else
        {
            Shield -= damage;
        }
        
    }
    public void SelectMe()
    {
        DOTween.Kill(_sp);
        _sp.transform.DOPunchScale(Vector3.one * 0.5f, 0.3f);
    }
}