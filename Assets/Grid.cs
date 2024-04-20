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
    public List<Grid> Brothers;

    [SerializeField] private List<Transform> _directions;
    [SerializeField] private LayerMask _grid;
    public GameObject Slot;

    void Start()
    {
        _startScale = transform.localScale;
        InitializeBrothers();
    }


    private void InitializeBrothers()
    {
        for (int i = 0; i < _directions.Count; i++)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(_directions[i].position, _directions[i].up, 1f, _grid);
            if (hits.Length > 0)
            {
                if (hits[0].collider.gameObject != gameObject)
                {
                    hits[0].collider.GetComponentInParent<Grid>().Brothers.Add(this);
                }
            }
        }
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