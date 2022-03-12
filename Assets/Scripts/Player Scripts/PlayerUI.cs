using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private PlayerStats playerStats;
    public Slider health;
    public Slider armor;

    void Start()
    {
        playerStats = GameObject.Find("Player").gameObject.GetComponent<PlayerStats>();
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
    }
}
