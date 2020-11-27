using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] float _timeBetweenSpwan = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ContinuellySpwanningEnemy());
    }
    IEnumerator ContinuellySpwanningEnemy()
    {
        while (true) // Forever
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_timeBetweenSpwan);
        }
    }
}

