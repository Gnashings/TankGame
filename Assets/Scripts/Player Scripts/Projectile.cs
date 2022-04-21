using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, PooledObjects
{
    // Start is called before the first frame update

    public AudioSource shotSound;
    
    public float killOffTimer;
    public GameObject effects;
    public SphereCollider exp;
    public Rigidbody rb;
    [Header("Explosive effects")]
    public Explosion explosion;

    private float damage;
    private bool dealsDamage;
    private bool isExplosive;
    private bool chadShot;
    public void OnObjectSpawn()
    {
        //killOffTimer = meme.clip.length;
        if (effects != null)
        {
            Instantiate(effects, transform.position, transform.rotation);
        }
        //shotSound.Play();
        gameObject.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        exp.enabled = true;
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnBecameInvisible()
    {
        ShutDown();
    }

    public void ShutDown()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        exp.enabled = false;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(chadShot == true && other.gameObject.GetComponent<NormalProjectile>() != false)
        {
            Destroy(other.gameObject);
            return;
        }
        if (!other.CompareTag("Player") &&
            !other.CompareTag("AutoTurret") &&
            !other.CompareTag("Spawner") &&
            !other.gameObject.GetComponent<NormalProjectile>() != false)
        {
            if(isExplosive)
            {
                explosion.Explode();
            }
            if (dealsDamage && other.CompareTag("Enemy"))
            {
                if (other.gameObject.GetComponentInParent<EnemyStats>() != null)
                {
                    other.gameObject.GetComponentInParent<EnemyStats>().TakeDamage(damage);
                }
            }
            ShutDown();
            //print(other.tag +" TARGET HIT "+other.name);
        }

    }

    public void SetFollowthrough(bool gigaChad)
    {
        chadShot = gigaChad;
    }

    public void SetExplosive(bool isExp)
    {
        isExplosive = isExp;
    }

    public void SetDealsDamage(bool isDmg)
    {
        dealsDamage = isDmg;
    }

    public void SetDamage(float damageNum)
    {
        damage = damageNum;
    }
    public void SetEffects(GameObject fx)
    {
        effects = fx;
    }
}
