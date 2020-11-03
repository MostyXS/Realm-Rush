using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>(); //key, object
    Queue<Waypoint> queue = new Queue<Waypoint>();
    
    bool isEndReached = false;
    [SerializeField] Waypoint startingWaypoint, endingWaypoint;
    Waypoint searchCenter; //current Search Center
    List<Waypoint> path = new List<Waypoint>(); 
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        SetAsPath(endingWaypoint);
        Waypoint previous = endingWaypoint.exploredFrom;
        while (previous != startingWaypoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;

        }
        SetAsPath(startingWaypoint);
        path.Reverse();
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startingWaypoint);
        
        while (queue.Count>0 && !isEndReached)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
        print("Finished Pathfinding");
    }
    private void HaltIfEndFound()
    {   
        if (searchCenter == endingWaypoint)
        {
            isEndReached = true;
            print("Searching from end node, therefore stopping"); 
        }
        
    }

    private void ExploreNeighbours()
    {
        if (isEndReached) { return; }
        foreach (Vector2Int direction in directions)
        {
            
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }

        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (!neighbour.isExplored && !queue.Contains(neighbour))
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
        
        
    } 

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            bool isOverlapping = grid.ContainsKey(gridPos); //ContainsKey == AlreadyContainsKey
            if (isOverlapping)

                Debug.LogWarning("OverlappingLog" + waypoint);
            else
            {
                grid.Add(gridPos, waypoint); 
            }
        }
       
    }

    

}
