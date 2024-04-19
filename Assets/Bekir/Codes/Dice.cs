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
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private List<Transform> _diceFaces;
    [SerializeField] private DiceSystem _dicesystem;

    public int DiceNumber;
    private bool _canDiceRay;


    public void RollMe()
    {
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
            _rigidBody.useGravity = true;
            _rigidBody.AddForceAtPosition(_punchForceRB * Mathf.Sign(Random.Range(-1, 1)), transform.localPosition + _punchPos, ForceMode.Impulse);
        }));
        
    }
    private int RaycastAll()
    {
        for (int i = 0; i < 7; i++)
        {
            RaycastHit[] hits = Physics.RaycastAll(_diceFaces[i].position, -_diceFaces[i].up, 30, _groundLayer);
            if(hits != null && hits[0].collider != null)
            {
                print(hits[0].transform.name);
                print(int.Parse(_diceFaces[i].name));
                return int.Parse(_diceFaces[i].name);
            }
        }
        return 0;
    }
    void Update()
    {
        if (!_canDiceRay) return;
        if (_rigidBody.velocity.magnitude == 0)
        {
            RaycastAll();
            _canDiceRay = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _canDiceRay = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _canDiceRay = false;
        }
    }
}