using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    void Start ()
    {
        PlayerProgress.ResetPlayerStats();
    }

    public void Play()
    {
        SceneManager.LoadScene("Parts_Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
