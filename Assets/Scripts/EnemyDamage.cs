using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int _hitPoints = 10;
    [SerializeField] ParticleSystem _hitParticles;
    [SerializeField] ParticleSystem _deathParticles;
    [SerializeField] AudioClip _damageSFX;
    [SerializeField] AudioClip _deathSFX;

    AudioSource _myAudioSource;

    private void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();
    }

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
        _myAudioSource.PlayOneShot(_damageSFX);
        _hitPoints -= 1;
    }

    void ProcessOfDeath()
    {
        AudioSource.PlayClipAtPoint(_deathSFX, Camera.main.transform.position);
        var DeathParticles = Instantiate(_deathParticles, transform.position, Quaternion.identity);
        DeathParticles.Play();
        Destroy(DeathParticles.gameObject, DeathParticles.main.duration);
        Destroy(gameObject);
    }
}
