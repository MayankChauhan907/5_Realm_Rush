using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public bool _isExplored = false;
    Vector2Int _gridPos;
    const int _gridSize = 10;
    public WayPoint ExploredFrom;
    [SerializeField] public bool _isplacebled = true;
    [SerializeField] Tower _towerPrefab;

    public int GetGridSize()
    {
        return _gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / _gridSize),
            Mathf.RoundToInt(transform.position.z / _gridSize)
        );
    }

    public void SetColor(Color color)
    {
        var TopMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        TopMeshRenderer.material.color = color;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isplacebled)
            {
                Instantiate(_towerPrefab, transform.position, Quaternion.identity);
                _isplacebled = false;
            }
            else
            {
                print("Can't Place Here");
            }
        }
    }
}
