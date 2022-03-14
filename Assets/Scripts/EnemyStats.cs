using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public EnemyStatsPerameters stats;

    public float health;

    void Start()
    {
        //stats.health = 0;
        health = 0;
        health = stats.health;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        
            if(health <= 0)
            {
                gameObject.SetActive(false);
            }
    }

    private void OnDisable()
    {
        //transform.GetComponentInParent<RoomSystem>().UnlockDoors();
        SendMessageUpwards("CheckDoorCanOpen");

    }
}
