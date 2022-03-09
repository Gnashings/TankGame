 
using UnityEngine;
using System.Collections;
 

 
public class NormalProjectile : BaseProjectile {
    Vector3 m_direction;
    bool m_fired;
    private float damageToPlayer;
 
    // Update is called once per frame
    void Update () {
        if(m_fired){
            transform.position += m_direction * (speed * Time.deltaTime);
        }
    }
 
    public override void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed){
        if(launcher && target){
            m_direction = (target.transform.position - launcher.transform.position).normalized;
            m_fired = true;
            damageToPlayer = damage;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        //do any other stuff you want here too
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<PlayerStats>().TakeDamage(damageToPlayer);
            Destroy(gameObject);
        }
    }


}
 