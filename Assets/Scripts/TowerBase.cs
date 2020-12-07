using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{

    [SerializeField] Tower _towerPrefab;
    [SerializeField] int _towerLimit = 5;
    [SerializeField] Transform _towerParent;

    Queue<Tower> _towers = new Queue<Tower>();

    public void AddTower(WayPoint BaseWayPoint)
    {
        int _numOfTower = _towers.Count;

        if (_numOfTower < _towerLimit)
        {
            InstantiateNewTower(BaseWayPoint);
        }
        else
        {
            MoveLastTower(BaseWayPoint);
        }

    }

    private void InstantiateNewTower(WayPoint NewBaseWayPoint)
    {
        Tower NewTower = Instantiate(_towerPrefab, NewBaseWayPoint.transform.position, Quaternion.identity);
        NewTower.transform.parent = _towerParent;
        NewBaseWayPoint._isplacebled = false;

        NewTower.BaseWaypoint = NewBaseWayPoint;
        _towers.Enqueue(NewTower);
    }

    private void MoveLastTower(WayPoint NewBaseWayPoint)
    {
        var OldTower = _towers.Dequeue();
        OldTower.BaseWaypoint._isplacebled = true;

        OldTower.transform.position = NewBaseWayPoint.transform.position;
        _towers.Enqueue(OldTower);
    }
}
