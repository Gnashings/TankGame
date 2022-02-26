using UnityEngine;
using System.Collections;
 
public abstract class BaseProjectile : MonoBehaviour {
    [Tooltip("Set bullet speed")]
    public float speed = 5.0f;
 
    void OnCollisionEnter(Collision collision)
    {
        
  //do any other stuff you want here too
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    
    public abstract void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed);
}
 