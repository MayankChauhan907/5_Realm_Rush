using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class EditorSnap : MonoBehaviour
{
    TextMesh textMesh;
    WayPoint wayPoint;

    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        wayPoint = GetComponent<WayPoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateTextName();
    }

    private void SnapToGrid()
    {
        var GridSize = wayPoint.GetGridSize();
        transform.position = new Vector3(
            wayPoint.GetGridPos().x * GridSize,
            0f,
            wayPoint.GetGridPos().y * GridSize
        );
    }

    private void UpdateTextName()
    {
        textMesh.text = wayPoint.GetGridPos().x + "," + wayPoint.GetGridPos().y;
        this.gameObject.name = textMesh.text;
    }
}
