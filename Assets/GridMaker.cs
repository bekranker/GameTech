using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class GridMaker : MonoBehaviour
{

    [Header("Grid Settings")]
    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private Grid _gridPrefab;
    [SerializeField] private Transform _parent;
    [Header("Tile Settings")]
    [SerializeField] private float _outerSize;
    [SerializeField] private float _innerSize;
    [SerializeField] private float _height;


    [Button]
    public void GridCreate()
    {
        for (int y = 0; y < _gridSize.y; y++)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                Transform tile = Instantiate(_gridPrefab, _parent).transform;
                tile.transform.position = GetPositionForHexCoordinate(new Vector2Int(x, y));
            }
        }
    }
    private Vector2 GetPositionForHexCoordinate(Vector2Int coordinate)
    {
        int column = coordinate.x;
        int row = coordinate.y;
        float width;
        float height;
        float xPosition;
        float yPosition;
        bool shouldOffset;
        float horizontalDistance;
        float verticleDistance;
        float offset;
        float size = _outerSize;

        shouldOffset = (row % 2) == 0;
        width = Mathf.Sqrt(3) * size;
        height = 2f * size;
        horizontalDistance = width;
        verticleDistance = height * (3f/4f);

        offset = (shouldOffset) ? width / 2 : 0;

        xPosition = (column * (horizontalDistance)) + offset;
        yPosition = (row * verticleDistance);
 
        return new Vector2(xPosition, yPosition);
    }
}