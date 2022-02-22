using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource explosionSound;
    public AudioSource meme;
    public float killOffTimer;
    public GameObject particles;
    private float timer;
    private float totalLifeTime;
    private bool startTimer;
    public BoxCollider body;
    public SphereCollider exp;

    [Header("Explosive effects")]
    public float force;
    public float range;
    public float upMod;
    void Start()
    {
        //killOffTimer = meme.clip.length;
        startTimer = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startTimer)
        {
            timer += Time.deltaTime;
            if(timer >= killOffTimer)
            {
                Destroy(gameObject);
            }
        }

        totalLifeTime += Time.deltaTime;
        if(totalLifeTime >= 20)
        {
            Destroy(gameObject);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {

        if(!collision.collider.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            body.enabled = false;
            exp.enabled = true;
            Instantiate(particles, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {

            other.GetComponentInParent<Rigidbody>().AddExplosionForce(force, other.ClosestPoint(gameObject.transform.position), range, upMod);
            Debug.Log(other.name);
            
            //exp.enabled = false;
            
        }
        else
            Destroy(gameObject);

    }
    
}
