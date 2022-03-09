using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class ShootingSystem : MonoBehaviour {
    public float fireRate;
    public int damage;
    public float fieldOfView;
    public GameObject projectile;
    public List<GameObject> projectileSpawns;
 
    List<GameObject> lastProjectilesShot = new List<GameObject>();
    float m_fireTimer = 0.0f;
    public GameObject target;
 

void Start()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");

        
    }


    // Update is called once per frame
    void Update () {
        if(!target)
        {
            
 
            return;
        }

            m_fireTimer += Time.deltaTime;
 
            if(m_fireTimer >= fireRate){
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
             
                if(angle < fieldOfView){
                    SpawnProjectiles();
                 
                    m_fireTimer = 0.0f;
                }
            }
     
    }
 
    void SpawnProjectiles(){
        if(!projectile){
            return;
        }
 
        lastProjectilesShot.Clear();
 
        for(int i = 0; i < projectileSpawns.Count; i++){
            if(projectileSpawns[i]){
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, Quaternion.Euler(projectileSpawns[i].transform.forward)) as GameObject;
                proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawns[i], target, damage, fireRate);
 
                lastProjectilesShot.Add(proj);
            }
        }
    }
 
    public void SetTarget(GameObject targetObj){
        target = targetObj;
    }
 
    void RemoveLastProjectiles()
    {
        while(lastProjectilesShot.Count > 0){
            Destroy(lastProjectilesShot[0]);
            lastProjectilesShot.RemoveAt(0);
        }
    }
}