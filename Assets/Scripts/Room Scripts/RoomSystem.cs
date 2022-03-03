using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    [Tooltip("Set all doors here")]
    public GameObject[] doors;

    [Tooltip("Set all enemy spawn points here")]
    public Transform[] spawnPointList;

    private GameObject[] EnemyList;
    private BoxCollider trigger;
    private int enemyCount;
    private int enemiesKilled;
    void Start()
    {
        trigger = gameObject.GetComponent<BoxCollider>();
        spawnPointList = Array.FindAll(GetComponentsInChildren<Transform>(), child => child != this.transform);
       
    }

    void Update()
    {
        
    }

    private void ReleaseEnemies()
    {
        foreach (Transform spawner in spawnPointList)
        {
            spawner.gameObject.GetComponent<SpawnEnemy>().TriggerEnemy();
            enemyCount++;
        }
    }
    public void LockDoors()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }
    }
    public void UnlockDoors()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
    }

    public void CheckDoorCanOpen()
    {
        enemiesKilled++;
        if(enemiesKilled == enemyCount)
        {
            UnlockDoors();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            trigger.enabled = false;
            ReleaseEnemies();
            LockDoors();
        }
    }

}
