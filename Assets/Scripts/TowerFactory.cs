using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    Queue<Tower> towers = new Queue<Tower>();
    int towersPlaced = 0;
    
    
        public void TowerAdd(Waypoint baseWaypoint)
        {
        if (!(towersPlaced == towerLimit))
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            
            MoveExisting(baseWaypoint);
        }

    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, transform);
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        towers.Enqueue(newTower);
        towersPlaced++;
    }

    private void MoveExisting(Waypoint newBaseWaypoint)
    {
        
        var oldTower = towers.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;
        towers.Enqueue(oldTower);
        

    }

}
