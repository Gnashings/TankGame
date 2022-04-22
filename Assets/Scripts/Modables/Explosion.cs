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

        if(explosion.particles != null)
        {
            Instantiate(explosion.particles, transform.position, transform.rotation);
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
            //bl = new Vector3(other.ClosestPointOnBounds(gameObject.transform.position).x, other.ClosestPointOnBounds(gameObject.transform.position).y + 0.05f, other.ClosestPointOnBounds(gameObject.transform.position).z);
            //other.ClosestPointOnBounds(gameObject.transform.position).y 
            rb.AddExplosionForce(explosion.force, other.ClosestPointOnBounds(gameObject.transform.position), explosion.radius, explosion.upwardforce, ForceMode.VelocityChange);
            //rb.AddExplosionForce(explosion.force, other.ClosestPoint(gameObject.transform.position), explosion.radius, 0, ForceMode.VelocityChange);
        }
        if (explosion.canAffectEnemies && other.CompareTag("Enemy"))
        {
            rb.AddExplosionForce(explosion.force, transform.position, explosion.radius);
        }
        else
        {
            //print(other.tag);
            if (other.tag.Equals("Mine"))
            {
                rb.AddExplosionForce(25 , other.ClosestPoint(gameObject.transform.position), 10, 2, ForceMode.VelocityChange);
            }

            
        }
    }

    private void DamageTargets(Collider other)
    {
        if(explosion.canDamageEnemies && other.CompareTag("Enemy"))
        {
            //Debug.Log("EXPLOSION.CS: NO ENEMY HEALTH IMPLIMENTED YET");
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<EnemyStats>().TakeDamage(explosion.damage * (1 + PlayerProgress.roided));
            //Debug.Log(" HIT " + other.tag + " FOR: " + explosion.damage * (1 + PlayerProgress.roided) + " EXP DAMAGE");
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
