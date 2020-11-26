using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int _hitPoints = 10;

    void OnParticleCollision(GameObject other)
    {
        GettingHits();
        if (_hitPoints <= 0)
        {
            ProcessOfDeath();
        }
    }

    void GettingHits()
    {
        _hitPoints -= 1;
    }

    void ProcessOfDeath()
    {
        Destroy(transform.parent.gameObject);
    }
}
