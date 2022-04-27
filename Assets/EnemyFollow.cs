using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public EnemyStats enemyStats;
    public NavMeshAgent enemyNavMesh;
    private Transform player;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
          if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        //enemyNavMesh.SetDestination(player.position);
        //Debug.Log("REMAINING:" + enemy.remainingDistance + " STOPPING:" + enemy.stoppingDistance);
    }
    

    void FixedUpdate()
    {
        CanMove();
    }

    private void LateUpdate()
    {
        if(enemyStats.stats.canMove)
        {
            if (enemyNavMesh.remainingDistance < enemyNavMesh.stoppingDistance)
            {
                if (enemyStats.isBomber)
                {
                    enemyStats.TakeDamage(10000);
                }
            }
        }

    }
    void CanMove()
    {
        if(enemyStats.stats.canMove)
        {
            enemyNavMesh.SetDestination(player.position);
        }
    }
}
