using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int _hitPoints = 10;
    [SerializeField] ParticleSystem _hitParticles;
    [SerializeField] ParticleSystem _deathParticles;

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
        _hitParticles.Play();
        _hitPoints -= 1;
    }

    void ProcessOfDeath()
    {
        var DeathParticles = Instantiate(_deathParticles, transform.position, Quaternion.identity);
        DeathParticles.Play();
        Destroy(DeathParticles.gameObject, DeathParticles.main.duration);
        Destroy(gameObject);
    }
}
