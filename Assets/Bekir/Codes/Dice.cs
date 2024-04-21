using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class Dice : MonoBehaviour
{

    [SerializeField] private Vector3 _punchForceDT;
    [SerializeField] private Vector3 _punchForceRB;
    [SerializeField] private Vector3 _punchPos;

    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _outSpeedDT;
    [SerializeField] private float _fadeOutDelayCount;

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private List<Transform> _diceFaces;
    [SerializeField] private DiceSystem _dicesystem;
    public DiceTypeSCB DiceType;

    public int DiceNumber;
    private bool _canDiceRay;
    private bool _canCollide;
    private Vector3 _statPosition;


    void Start()
    {
        _statPosition = transform.position;
    }

    public void RollMe()
    {
        transform.position = _statPosition;
        transform.localScale = new Vector3(0, 0, 0);
        Sequence sequence = DOTween.Sequence();
        transform.localScale = new Vector3(15, 15, 15);
        sequence.Append(transform.DOPunchScale(_punchForceDT, 0.5f));
        sequence.Append(DOVirtual.DelayedCall(0f, () => 
        {
            _rigidBody.useGravity = false;
        }));
        sequence.Append(DOVirtual.DelayedCall(0f, () => 
        {
            _canCollide = true;
            _rigidBody.useGravity = true;
            _rigidBody.AddForceAtPosition(_punchForceRB * Mathf.Sign(Random.Range(-1, 1)), transform.localPosition + _punchPos, ForceMode.Impulse);
            _dicesystem.SetMusics();
        }));
    }
    private void RaycastAll()
    {
        for (int i = 0; i < 6; i++)
        {
            RaycastHit[] hits = Physics.RaycastAll(_diceFaces[i].position, -_diceFaces[i].up, 3, _groundLayer);
            if(hits != null && hits.Length > 0)
            {
                for (int a = 0; a < hits.Length; a++)
                {
                    if (hits[a].collider != null)
                    {
                        print(hits[a].collider.name);
                    }
                }
                DiceNumber = int.Parse(_diceFaces[i].name);
                _dicesystem.DidRoll = true;
                Begining();
                return;
            }
        }
    }
    private void Begining()
    {
        //_dicesystem.SetConfigs();
        DOVirtual.DelayedCall(_fadeOutDelayCount, () =>
        {
            _dicesystem.RolledDiceCount++;
            transform.DOScale(Vector3.zero, _outSpeedDT * 1.2f);
            _rigidBody.useGravity = false;
        });
    }
    void Update()
    {
        if (!_canDiceRay) return;
        if (_rigidBody.velocity.magnitude == 0)
        {
            print("RaycastAll");
            RaycastAll();
            _canDiceRay = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(!_canCollide) return;
        if(collision.gameObject.CompareTag("Ground"))
        {
            _canDiceRay = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(!_canCollide) return;

        if(collision.gameObject.CompareTag("Ground"))
        {
            print("cide collide with ground");
            _canDiceRay = false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawRay(_diceFaces[0].position, -_diceFaces[0].up * 3);
        Gizmos.DrawRay(_diceFaces[1].position, -_diceFaces[1].up * 3);
        Gizmos.DrawRay(_diceFaces[2].position, -_diceFaces[2].up * 3);
        Gizmos.DrawRay(_diceFaces[3].position, -_diceFaces[3].up * 3);
        Gizmos.DrawRay(_diceFaces[4].position, -_diceFaces[4].up * 3);
        Gizmos.DrawRay(_diceFaces[5].position, -_diceFaces[5].up * 3);
    }
}