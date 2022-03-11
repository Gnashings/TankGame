using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDirector : MonoBehaviour
{
    public bool roomsCompleted;
    //[HideInInspector]
    public List<RoomSystem> rooms = new List<RoomSystem>();

    // Start is called before the first frame update
    void Start()
    {
        roomsCompleted = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddThisRoom(RoomSystem room)
    {
        rooms.Add(room);
    }

    public void CheckLevelCompletion()
    {
        //bool isCompleted = false;
        foreach (RoomSystem room in rooms)
        {
            if (room.roomCompleted == false)
            {
                roomsCompleted = false;
                return;
            }
            else
                roomsCompleted = true;
        }
        if(roomsCompleted == true)
        {
            print("ROOMS ARE ALL COMPLETED");
        }
    }
}
