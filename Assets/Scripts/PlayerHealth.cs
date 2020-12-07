using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _healthPoints = 10;
    [SerializeField] int _hitPoints = 1;
    [SerializeField] AudioClip _playerDamageSFX;

    void OnTriggerEnter(Collider other)
    {
        _healthPoints -= _hitPoints;
        GetComponent<AudioSource>().PlayOneShot(_playerDamageSFX);
    }
}