using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
            yield return new WaitForSeconds(1f);
        }
    }
}
