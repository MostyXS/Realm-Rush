using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
   
    TextMesh textMesh;
   
    Waypoint waypoint;
    int gridSize;
    private void Awake()
    {
        if (GetComponentInChildren<TextMesh>())
        textMesh = GetComponentInChildren<TextMesh>();
        waypoint = GetComponent<Waypoint>();
    }
    
    void Update()
    {
        
        SnapToGrid();
    }

    private void SnapToGrid()
    {

        gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x*gridSize, 0f, waypoint.GetGridPos().y* gridSize);
    }

    /*private void UpdateLabel()
    {
        textMesh.text = waypoint.GetGridPos().x+","+waypoint.GetGridPos().y;
        gameObject.name = textMesh.text;
    }*/ //Old Content, remind you can create block yourself
}
