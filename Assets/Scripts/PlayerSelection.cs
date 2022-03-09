using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    public GameObject turret;
    public GameObject body;
    public GameObject tracks;

    private string selection;
    private bool choseTurret;
    private bool choseBody;
    private bool choseTracks;

    private GameObject gameDirector;

    void Start()
    {
        CheckChoices();
        gameDirector = GameObject.Find("GameDirector");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void TurretSelection(string thisString)
    {
        selection = thisString;
        choseTurret = true;
        choseBody   = false;
        choseTracks = false;
        print("turret " + thisString);
    }

    public void BodySelection(string thisString)
    {
        selection = thisString;
        choseTurret = false;
        choseBody   = true;
        choseTracks = false;
        print("body " + thisString);
    }
    public void TrackSelection(string thisString)
    {
        selection = thisString;
        choseTurret = false;
        choseBody   = false;
        choseTracks = true;
        print("track " + thisString);
    }

    public void PlayGame()
    {
        if(choseTurret == true)
        {
            PlayerProgress.SetTurret(selection);
        }
        if(choseBody == true)
        {
            PlayerProgress.SetBody(selection);
        }
        if(choseTracks == true)
        {
            PlayerProgress.SetTracks(selection);
        }
        //DEBUG: SceneManager.LoadScene("Menu");
        SceneManager.LoadScene("SampleScene");
        //LIVE: SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void CheckChoices()
    {
        if(PlayerProgress.hasTurret == true)
        {
            turret.SetActive(false);
        }

        if (PlayerProgress.hasBody == true)
        {
            body.SetActive(false);
        }

        if (PlayerProgress.hasTracks == true)
        {
            tracks.SetActive(false);
        }
    }
}
