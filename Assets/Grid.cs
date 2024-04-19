using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class Grid : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _punchForceDT;
    [SerializeField] private SpriteRenderer _sp;
    private Vector3 _startScale;

    void Start()
    {
        _startScale = transform.localScale;
    }

    public void Enterted()
    {
        transform.localScale = _startScale;
        DOTween.Kill(_sp);
        _sp.DOFade(0.3f, _speed);
        transform.DOPunchScale(Vector3.one * _punchForceDT, _speed).OnComplete(() => transform.localScale = _startScale);
    }

    public void Exited()
    {
        transform.localScale = _startScale;
        DOTween.Kill(_sp);
        _sp.DOFade(0, _speed);
    }
}