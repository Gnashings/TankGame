using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerProgress 
{
    public static bool hasTurret;
    public static bool hasBody;
    public static bool hasTracks;
    public static string curTurret;
    public static string curBody;
    public static string curTracks;

    public static bool paused;
    public static string curLevel;
    public static int levelsCompleted;
    public static bool death;
    public static void SetTurret(string selection)
    {
        curTurret = selection;
        hasTurret = true;
    }

    public static void SetBody(string selection)
    {
        curBody = selection;
        hasBody = true;
    }

    public static void SetTracks(string selection)
    {
        curTracks = selection;
        hasTracks = true;
    }

    public static void ReadData()
    {
        Debug.Log("Turret: " + hasTurret);
        Debug.Log("Body: " + hasBody);
        Debug.Log("Tracks " + hasTracks);
    }

    public static bool ChoseAbility()
    {
        bool hasAbility = false;
        if(hasTurret)
        {
            hasAbility = true;
        }
        if(hasBody)
        {
            hasAbility = true;
        }
        if (hasTracks)
        {
            hasAbility = true;
        }
        return hasAbility;

    }

    public static void ResetPlayerStats()
    {
        hasTurret = false;
        hasBody = false;
        hasTracks = false;

        curTurret = null;
        curBody = null;
        curTracks = null;

        death = false;
        levelsCompleted = 0;
        Debug.Log("all stats resets");
    }
}
