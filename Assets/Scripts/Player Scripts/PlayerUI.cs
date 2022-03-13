using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private GameObject player;
    private PlayerStats playerStats;
    private PlayerInputControls playerInputs;
    public Slider health;
    public Slider armor;
    public Canvas pauseMenu;
    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerInputs = player.GetComponent<PlayerInputControls>();
        health.maxValue = playerStats.totalHealth;
        health.value = playerStats.health;
        armor.maxValue = playerStats.totalArmor;
        armor.value = playerStats.armor;
    }

    // Update is called once per frame
    void Update()
    {
        armor.value = playerStats.armor;
        health.value = playerStats.health;
        if(playerInputs.paused)
        {
            if(pauseMenu.enabled)
            {
                GameUnpause();
            }
            else GamePause();
        }
    }

    private void GamePause()
    {
        PlayerProgress.paused = true;
        pauseMenu.enabled = true;
        Time.timeScale = 0;
        playerInputs.UnlockMouse();
    }

    public void GameUnpause()
    {
        PlayerProgress.paused = false;
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        playerInputs.LockMouse();
    }

    public void MainMenuInputCleanup()
    {
        PlayerProgress.paused = false;
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        playerInputs.UnlockMouse();
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
