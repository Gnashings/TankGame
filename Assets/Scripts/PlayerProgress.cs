using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerProgress 
{
    public static bool hasTurret;
    public static bool hasBody;
    public static bool hasTrack;
    public static string curTurret;
    public static bool TestingScript(bool flash)
    {
        return flash;
    }

    public static void SetTurret()
    {
        curTurret = "Sasha";
        hasTurret = true;
    }

    public static void SetBody()
    {
        hasBody = true;
    }

    public static void SetTracks()
    {
        hasTrack = true;
    }

    public static void ReadData()
    {
        Debug.Log("Turret: " + hasTurret);
        Debug.Log("Body: " + hasBody);
        Debug.Log("Tracks " + hasTrack);
    }
}
