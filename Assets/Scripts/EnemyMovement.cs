using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 1f;
    [SerializeField] ParticleSystem endingParticles;
    [SerializeField] int damage = 2;
    private void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

     IEnumerator FollowPath(List<Waypoint> path)
    {
        Debug.Log("Starting Patrol...");
        for (int i= 0; i< path.Count;i++)
        {
            
            transform.position = path[i].transform.position;
            Debug.Log("Visiting:" + path[i]);
            yield return new WaitForSeconds(movementPeriod);
        }
        Instantiate(endingParticles, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }
    public int GetDamage()
    {
        return damage;
    }
}
