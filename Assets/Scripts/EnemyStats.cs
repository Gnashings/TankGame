using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public EnemyStatsPerameters stats;

    float health;
    void Start()
    {
        stats.health = 0;
        health = stats.health;
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        
            if(health <= 0)
            {
                gameObject.SetActive(false);
            }
    }
}
