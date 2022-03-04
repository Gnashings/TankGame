using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles when things go boom
/// </summary>
public class Explosion : MonoBehaviour
{
    public ExplosionParameters explosion;

    public void Explode()
    {
        if(explosion.explosionSound != null)
        {
            
        }
        
        Physics.OverlapSphere(transform.position, explosion.radius);
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosion.radius);

        foreach (Collider hitObj in colliders)
        {
            Rigidbody rb = hitObj.transform.GetComponentInParent<Rigidbody>();
            if (rb != null)
            {
                DoPhysics(hitObj, rb);
            }
            
            DamageTargets(hitObj);
        }
    }

    private void DoPhysics(Collider other, Rigidbody rb)
    {
        if (explosion.canAffectPlayer && other.CompareTag("Player"))
        {
            rb.AddExplosionForce(explosion.force, other.ClosestPoint(gameObject.transform.position), explosion.radius);
            
        }
        if (explosion.canAffectEnemies && other.CompareTag("Enemy"))
        {
            rb.AddExplosionForce(explosion.force, transform.position, explosion.radius);
        }
    }

    private void DamageTargets(Collider other)
    {
        if(explosion.canDamageEnemies && other.CompareTag("Enemy"))
        {
            Debug.Log("NO ENEMY HEALTH IMPLIMENTED YET");
            other.gameObject.SetActive(false);
        }
        if(explosion.canDamagePlayer && other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<PlayerStats>().TakeDamage(explosion.damage);     
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosion.radius);
    }
}
