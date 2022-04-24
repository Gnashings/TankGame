using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBomberFollow : MonoBehaviour
{
    public EnemyStats enemyStats;
    public NavMeshAgent enemy;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
          if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy.SetDestination(player.position);
        Debug.Log("REMAINING:" + enemy.remainingDistance + " STOPPING:" + enemy.stoppingDistance);
    }
    NavMeshPath path;
    // Update is called once per frame
    void FixedUpdate()
    {
        enemy.SetDestination(player.position); 
    }

    private void LateUpdate()
    {
        if (enemy.remainingDistance < enemy.stoppingDistance)
        {
            if (enemyStats.isBomber)
            {
                enemyStats.TakeDamage(10000);
            }
        }
    }
}
