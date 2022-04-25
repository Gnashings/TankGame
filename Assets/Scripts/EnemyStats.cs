using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public EnemyStatsPerameters stats;

    public float health;
    public bool isBomber;
    //nash edit
    private float totalHP;
    public Explosion explosion;
    private bool gibbed;
    void Start()
    {
        //stats.health = 0;
        health = 0;
        health = stats.health;
        totalHP = stats.health;
        gibbed = false;
    }
    public void TakeDamage(float damage)
    {
        if (totalHP < damage)
        {
            gibbed = true;
            gameObject.SetActive(false);
            return;
        }

        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        //transform.GetComponentInParent<RoomSystem>().UnlockDoors();
        if(isBomber && explosion != null && gibbed == true)
        {
            InstaGib();
        } 
        SendMessageUpwards("CheckDoorCanOpen", SendMessageOptions.DontRequireReceiver);


    }

    private void InstaGib()
    {
        explosion.Explode();
        print("GIBBED");       
    }
}
