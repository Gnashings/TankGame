using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBomberFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
          if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }
}
