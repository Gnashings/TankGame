using UnityEngine;
using System.Collections;
 
public abstract class BaseProjectile : MonoBehaviour {
    [Tooltip("Set bullet speed")]
    public float speed = 5.0f;

    [Tooltip("Set bullet damage")]
    public float damage;
 
    void OnTriggerEnter(Collider other)
    {
        
  //do any other stuff you want here too
        if (other.gameObject.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }

    
    public abstract void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed);
}
 