using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer, _collectableDice, _enemy, _grid;
    [SerializeField] private Player _player;

    public bool _playerSelected;
    private Grid _previousGrid;

    void Update()
    {
        SelectPlayer();
        SelectMoveTarget();
        HoverGrid();
    }
    void SelectPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 10f, _playerLayer))
            {
                _playerSelected = true;
                _player.SelectMe();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            _playerSelected = false;
        }
    }
    void SelectMoveTarget()
    {
        if (!_playerSelected) return;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 10f, _grid);
            if (hits.Length > 0)
            {
                print("move to" + hits[0].collider.transform.position);
                _player.Move(hits[0].collider.transform.position);
            }
        }
    }
    void HoverGrid()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 10f, _grid);
        if (hits.Length > 0)
        {
            Grid grid = hits[0].collider.GetComponentInParent<Grid>();
            if (grid != _previousGrid)
            {
                if (_previousGrid != null)
                    _previousGrid.Exited();
                grid.Enterted();
                _previousGrid = grid;
            }
            else
            {
                return;
            }
        }
        else{
            return;
        }
    }
}