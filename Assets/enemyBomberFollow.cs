using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBomberFollow : MonoBehaviour
{
    public EnemyStats enemyStats;
    public NavMeshAgent enemyNavMesh;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
          if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyNavMesh.SetDestination(player.position);
        //Debug.Log("REMAINING:" + enemy.remainingDistance + " STOPPING:" + enemy.stoppingDistance);
    }
    NavMeshPath path;
    // Update is called once per frame
    void FixedUpdate()
    {
        CanMove();
    }

    private void LateUpdate()
    {
        if (enemyNavMesh.remainingDistance < enemyNavMesh.stoppingDistance)
        {
            if (enemyStats.isBomber)
            {
                enemyStats.TakeDamage(10000);
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
