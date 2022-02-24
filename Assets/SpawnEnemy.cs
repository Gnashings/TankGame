using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    private GameObject trackKill;
    //TODO TRACK THE DEATH OF EACH ENEMY SPAWNED
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    

    public void TriggerEnemy()
    {
       Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
