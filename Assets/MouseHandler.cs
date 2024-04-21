using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer, _collectableDice, _enemy, _grid, _slot;
    [SerializeField] private Player _player;
    [SerializeField] private LineRenderer _lineRenderr;
    [SerializeField] private DiceSystem _diceSystem;
    [SerializeField] private GameObject _infoCanvas;
    public bool _playerSelected;
    private bool _onEnemy;
    [SerializeField] private RollYourDiceHit _rollYourDiceHit;
    public bool Attacked;
    private int _playerClickedCount;

    void Start()
    {
        _infoCanvas.SetActive(false);
    }

    void Update()
    {
        SelectPlayer();
        SelectMoveTarget();
        HoverEnemy();
        HoldCollectableDice();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_diceSystem.DidRoll)
            {
                _player.GetComponent<Player>().ShieldBar.gameObject.SetActive(true);
                _player.GetComponent<Player>().Shield = _diceSystem.Defend;
            }
        }
    }
    void SelectPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 10f, _playerLayer))
            {
                if(!_diceSystem.DidRoll)
                {
                    _rollYourDiceHit.HitText = "Roll Your Dice First";
                    _rollYourDiceHit.GameHit();
                    return;
                }
                DOTween.Kill(this);
                DOVirtual.DelayedCall(0.1f, () => _playerSelected = true);
                _player.SelectMe();
                _lineRenderr.enabled = true;
                _infoCanvas.SetActive(true);
                _playerClickedCount++;
                
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            _playerSelected = false;
            _lineRenderr.enabled = false;
            _infoCanvas.SetActive(false);
            _playerClickedCount = 0;
        }
    }
    void SelectMoveTarget()
    {
        if (!_playerSelected) return;
        if (_onEnemy) return;



        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        
        if (_diceSystem.Movement > 0 && Vector2.Distance(mousePosition, _player.transform.position) <= _diceSystem.Movement)
        {
            _lineRenderr.enabled = true;
            _infoCanvas.SetActive(true);
            _player.CanWalk = true;
            _infoCanvas.transform.position = mousePosition + (Vector3.one * .1f);
            _lineRenderr.SetPosition(0, _player.transform.position);
            _lineRenderr.SetPosition(1, mousePosition);
            _playerClickedCount = 0;
            if (Input.GetMouseButtonDown(0))
            {
                _diceSystem.Movement -= Vector2.Distance(mousePosition, _player.transform.position);
                _player.Move(mousePosition);
                _lineRenderr.enabled = false;
                
            }
            _infoCanvas.GetComponentInChildren<TMP_Text>().text = Vector2.Distance(mousePosition, _player.transform.position).ToString(".") + "m";
        }
        else
        {
            _player.CanWalk = false;
            _lineRenderr.enabled = false;
            _infoCanvas.SetActive(false);
        }
    }
    void HoverEnemy()
    {
        if(!_playerSelected) return;
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 10f, _enemy);
        if (hits.Length > 0)
        {
                _playerClickedCount = 0;
                _onEnemy = true;
                _infoCanvas.SetActive(true);
                _lineRenderr.enabled = false;
                _infoCanvas.transform.position = hits[0].collider.transform.position + (Vector3.up * .7f);
            if (Vector2.Distance(hits[0].collider.transform.position, _player.transform.position) <= 2)
            {
                _infoCanvas.GetComponentInChildren<TMP_Text>().text =_diceSystem.Combat + "x";

                if (Input.GetMouseButtonDown(0) && !Attacked)
                {
                    hits[0].collider.GetComponent<IDamagable>().TakeDamage(_diceSystem.Combat);
                    _player.GetComponent<Animator>().Play("Combat");
                    Attacked = true;
                }
            }
            else
            {
                _infoCanvas.GetComponentInChildren<TMP_Text>().text = "Come Closer";
            }
        }
        else
        {
            _onEnemy = false;
        }
    }
    void HoldCollectableDice()
    {
        if(_playerSelected) return;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        RaycastHit2D[] collectableDiceHits = Physics2D.RaycastAll(mousePosition, Vector3.forward, 10f, _collectableDice);
        RaycastHit2D[] slotHits = Physics2D.RaycastAll(mousePosition, Vector3.forward, 10f, _slot);
        
        if (collectableDiceHits.Length > 0)
        {
            if (Input.GetMouseButton(0))
            {
                collectableDiceHits[0].collider.transform.position = mousePosition;
            }
            if (slotHits.Length > 0)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    print("Change Dice");
                    slotHits[0].collider.GetComponent<DiceHolder>().ChangeDice(collectableDiceHits[0].collider.GetComponent<CollectableDice>(), collectableDiceHits[0].collider.GetComponent<CollectableDice>()._sp.sprite);
                }
            }
        }
        
    }

}