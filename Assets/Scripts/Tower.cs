using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Parametrs")]
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange =10f;
    [SerializeField] ParticleSystem gun;
    Transform targetEnemy;
    public Waypoint baseWaypoint;
    

    void Update()
    {
        SetTargetEnemy();
        objectToPan.LookAt(targetEnemy);
        Shoot();
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyHealth>();
        if (sceneEnemies.Length == 0)  return;

        Transform closestEnemy = sceneEnemies[0].transform;
        
        foreach (EnemyHealth  testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform closestEnemy, Transform transform)
    {
        if (Vector3.Distance(transform.position, closestEnemy.transform.position) > Vector3.Distance(transform.position, transform.position)) //Сравнивает дистанцию между двумя объектами
            return transform; //Если дистанция до другого объекта ближе, то ставит приоритетной целью ближайшую
        else
            return closestEnemy; //Если ближайшая не изменилась ставит приоритетной целью ту же, что и была
    }

    private void Shoot()
    {
        if (targetEnemy && InRange())
        {
            if (!gun.isPlaying)
                gun.Play();
        }
        else
        {
            gun.Stop();
        }
    }

    private bool InRange()
    {
        return Vector3.Distance(transform.position, targetEnemy.transform.position) <= attackRange;
    }

}
