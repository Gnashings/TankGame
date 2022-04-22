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
    void Start()
    {
        //stats.health = 0;
        health = 0;
        health = stats.health;
        totalHP = stats.health;
    }
    public void TakeDamage(float damage)
    {
        print(damage);
        if (totalHP < damage)
        {
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
        if(isBomber)
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
