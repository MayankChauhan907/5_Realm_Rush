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
