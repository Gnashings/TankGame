using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBomberFollow : MonoBehaviour
{
    public EnemyStats enemyStats;
    public NavMeshAgent navMesh;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh.SetDestination(player.position);
        Debug.Log("REMAINING:" + navMesh.remainingDistance + " STOPPING:" + navMesh.stoppingDistance);
    }
    NavMeshPath path;
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void LateUpdate()
    {
        if (navMesh.remainingDistance < navMesh.stoppingDistance)
        {
            if (enemyStats.isBomber)
            {
                enemyStats.TakeDamage(10000);
            }
        }
    }

    void MoveToPlayer()
    {
        if(enemyStats.stats.canMove)
        {
            navMesh.SetDestination(player.position);
        }
    }
}
