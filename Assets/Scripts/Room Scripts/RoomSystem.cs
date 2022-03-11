using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    public LevelDirector director;
    [Tooltip("Set all doors here")]
    public List<GameObject> doors = new List<GameObject>();
    [Tooltip("All enemy spawn points appear here")]
    // Transform[] spawnPointList;
    public List<Transform> spawnPointList = new List<Transform>();
    private BoxCollider trigger;
    private int enemyCount;
    private int enemiesKilled;
    [HideInInspector]
    public bool roomCompleted;
    void Start()
    {
        if (director == null)
        {
            Debug.LogError("No Game Director attached to this room, please attach the director.");
        }
        if (spawnPointList.Count != 0)
        {
            Debug.LogWarning("The SpawnPoints list should be empty, please attach SpawnPoints in the children instead.");
        }
        if (doors.Count != 0)
        {
            Debug.LogWarning("The Doors list should be empty, please attach Doors in the children instead.");
        }

        trigger = gameObject.GetComponent<BoxCollider>();

        //Set each child object to a spawnpoint or a door
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Door")) doors.Add(child.gameObject);
            if (child.CompareTag("SpawnPoint")) spawnPointList.Add(child.transform);
        }

        //spawnPointList = Array.FindAll(GetComponentsInChildren<Transform>(), child => child != this.transform && !child.CompareTag("Door"));

        director.AddThisRoom(this.GetComponent<RoomSystem>());
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
    private void UnlockDoors()
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
            ReportRoomCompleted();
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

    private void ReportRoomCompleted()
    {
        roomCompleted = true;
        director.CheckLevelCompletion();
    }
}
