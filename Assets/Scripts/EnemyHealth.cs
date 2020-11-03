using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem deathParticles, hitParticles;
    
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);
        /*
        vfx = Instantiate (deathParticles, transform.position ,Quarternion.identity, transform.parent);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy (gameObject);
    */
    }

    private void ProcessHit()
    {
        hitPoints--;
        hitParticles.Play();
    }

   
 


}
