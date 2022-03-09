using UnityEngine;
using System.Collections;
 
public abstract class BaseProjectile : MonoBehaviour {
    [Tooltip("Set bullet speed")]
    public float speed = 5.0f;

    void OnTriggerEnter(Collider other)
    {

        //do any other stuff you want here too
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public abstract void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed);
}
 