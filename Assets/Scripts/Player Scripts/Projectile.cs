using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, PooledObjects
{
    // Start is called before the first frame update

    public AudioSource explosionSound;
    public float killOffTimer;
    public GameObject particles;
    public BoxCollider body;
    public SphereCollider exp;
    public Rigidbody rb;
    [Header("Explosive effects")]
    public Explosion explosion;

    private float damage;
    private bool isExplosive;
    public void OnObjectSpawn()
    {
        //killOffTimer = meme.clip.length;
        gameObject.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        exp.enabled = true;
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void BulletProperties()
    {
        if(isExplosive == true)
        {

        }
    }
    private void OnBecameInvisible()
    {
        ShutDown();
    }

    public void ShutDown()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        body.enabled = false;
        exp.enabled = false;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") &&
            !other.CompareTag("AutoTurret") &&
            !other.CompareTag("Spawner"))
        {

            ShutDown();
            Instantiate(particles, transform.position, transform.rotation);
            explosion.Explode();
            //print(other.tag +" "+other.name);
        }
        
    }
}
