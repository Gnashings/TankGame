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

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if(startTimer)
        {
            timer += Time.deltaTime;
            if(timer >= killOffTimer)
            {
                gameObject.SetActive(false);
            }
        }

        totalLifeTime += Time.deltaTime;
        if(totalLifeTime >= 20)
        {
            gameObject.SetActive(false);
        }*/

        //shot.AddForce(transform.forward);

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

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            body.enabled = false;
            exp.enabled = true;
            
            Instantiate(particles, transform.position, transform.rotation);
        }
        explosion.Explode();
    }*/
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
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {

            
            Debug.Log(other.name);
            
            //exp.enabled = false;
            if(other.CompareTag("Enemy"))
            {
                other.GetComponentInParent<Rigidbody>().AddExplosionForce(force, other.ClosestPoint(gameObject.transform.position), range, upMod);
                other.gameObject.SetActive(false);
                Debug.Log("ENEMY HIT");
            }
            
        }
        else
            Destroy(gameObject);
        
    }
    */
}
