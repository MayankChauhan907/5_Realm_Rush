using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

    [SerializeField] WayPoint _startPonit, _endPoint;
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    [SerializeField] bool _isRunning = true;
    WayPoint SearchingCenter;
    List<WayPoint> path = new List<WayPoint>();

    Vector2Int[] _directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<WayPoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void LoadBlocks()
    {
        var wayponis = FindObjectsOfType<WayPoint>();
        foreach (WayPoint wayPoint in wayponis)
        {
            var GridPos = wayPoint.GetGridPos();
            if (grid.ContainsKey(GridPos))
            {
                Debug.LogWarning("Block" + wayPoint + "Is Overlapped");
            }
            else
            {
                grid.Add(GridPos, wayPoint);
            }
        }
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(_startPonit);
        while (queue.Count > 0 && _isRunning)
        {
            SearchingCenter = queue.Dequeue();
            HalfIfEndFound();
            ExploreNeighbours();
            SearchingCenter._isExplored = true;
        }
    }

    private void HalfIfEndFound()
    {
        if (SearchingCenter == _endPoint)
        {
            _isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!_isRunning) { return; }

        foreach (Vector2Int Direction in _directions)
        {
            Vector2Int ExploringCoordinat = SearchingCenter.GetGridPos() + Direction;
            if (grid.ContainsKey(ExploringCoordinat))
            {
                QueueNewNeighbour(ExploringCoordinat);
            }
        }
    }

    private void QueueNewNeighbour(Vector2Int ExploringCoordinat)
    {
        WayPoint neighbour = grid[ExploringCoordinat];
        if (neighbour._isExplored || queue.Contains(neighbour))
        {
            //Do nothing
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.ExploredFrom = SearchingCenter;
        }
    }

    private void CreatePath()
    {
        SetAsPath(_endPoint);

        WayPoint Previous = _endPoint.ExploredFrom;
        while (Previous != _startPonit)
        {
            SetAsPath(Previous);
            Previous = Previous.ExploredFrom;
        }

        path.Add(_startPonit);
        _startPonit._isplacebled = false;
        path.Reverse();
    }

    private void SetAsPath(WayPoint wayPoint)
    {
        path.Add(wayPoint);
        wayPoint._isplacebled = false;
    }

}