using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem _goalParticles;
    [Tooltip("In seconds")] [SerializeField] float _spwannigRate = 0.5f;

    void Start()
    {
        PathFinding pathFinding = FindObjectOfType<PathFinding>();
        var Path = pathFinding.GetPath();
        StartCoroutine(StartFindingPath(Path));
    }

    IEnumerator StartFindingPath(List<WayPoint> path)
    {
        foreach (WayPoint Child in path)
        {
            transform.position = new Vector3(Child.transform.position.x, transform.position.y, Child.transform.position.z);
            yield return new WaitForSeconds(_spwannigRate);
        }
        GoalFX();
    }

    void GoalFX()
    {
        var GoalPartile = Instantiate(_goalParticles, transform.position, Quaternion.identity);
        GoalPartile.Play();
        Destroy(GoalPartile.gameObject, GoalPartile.main.duration);
        Destroy(gameObject);
    }
}
