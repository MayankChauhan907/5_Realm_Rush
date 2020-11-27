using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform _gameobjectToPan;
    [SerializeField] Transform _targetEnemy;
    [SerializeField] float _attackeRange = 20;
    [SerializeField] ParticleSystem _bullets;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (_targetEnemy)
        {
            _gameobjectToPan.LookAt(_targetEnemy);
            CheckForEnemy();
        }
        else
        {
            Shoot(false);
        }

    }

    void SetTargetEnemy()
    {
        var Enemies = FindObjectsOfType<Enemy>();
        if (Enemies.Length == 0) { return; }

        Transform ClosestEnemy = Enemies[0].transform;

        foreach (Enemy TestEnemy in Enemies)
        {
            ClosestEnemy = GetClosestEnemy(ClosestEnemy, TestEnemy.transform);
        }

        _targetEnemy = ClosestEnemy;
    }

    private Transform GetClosestEnemy(Transform TargetA, Transform TargetB)
    {
        var DistoA = Vector3.Distance(transform.position, TargetA.position);
        var DistoB = Vector3.Distance(transform.position, TargetB.position);

        if (DistoA < DistoB)
        {
            return TargetA;
        }
        return TargetB;
    }

    void CheckForEnemy()
    {
        var DistantToEnemy = Vector3.Distance(_targetEnemy.transform.position, gameObject.transform.position);
        if (DistantToEnemy <= _attackeRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    void Shoot(bool isAttack)
    {
        var Emission = _bullets.emission;
        Emission.enabled = isAttack;
    }
}
