﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint exploredFrom;
    const int gridSize = 10;
    public bool isExplored = false;
    public bool isPlaceable = true;
    public Vector2Int GetGridPos()
    {    
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize),
                              Mathf.RoundToInt(transform.position.z / gridSize)); //Возвращает позицию сетки
    }
    public int GetGridSize()
    {
        return gridSize;
    }
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
    //TO DELETE
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
                FindObjectOfType<TowerFactory>().TowerAdd(this);
            else
            {
                Debug.Log("Can't place on this block");
            }
        }
    }

    
}
