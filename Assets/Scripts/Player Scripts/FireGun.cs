using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles the firing of the weapon and damage properties
/// </summary>
public class FireGun : MonoBehaviour
{
    private PlayerInputControls inputs;


    [Tooltip("Where to shoot projectile from")]
    public GameObject muzzle;
    //[HideInInspector]
    public AudioSource fireSound;
    public AudioSource fireSoundAlt;
    private float firingCooldown;
    private float bulletVelocity;
    private bool canFire;
    private float accuracy;
    private float damage;
    private string bulletType;
    void Start()
    {
        inputs = gameObject.GetComponentInParent<PlayerInputControls>();
        canFire = true;
        
        if(bulletVelocity <= 1)
        {
            bulletVelocity = 2000f;
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
        SashaBaby();
        
        //FireTurret();
    }

    private void SashaBaby()
    {
        
        if (inputs.IsFireHeld() == true && canFire)
        {
            
            if (firingCooldown != 0)
            {
                
                canFire = false;
                SashaGun();
                StartCoroutine(StartCooldown());
            }
        }
    }
    private void FireTurret()
    {

        if (inputs.Firing && canFire)
        {
            /* INSTANTIATION METHOD
            GameObject rocketInstance;
            Quaternion firingDirection = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 0));
            rocketInstance = Instantiate(normalShot, muzzle.transform.position, firingDirection) as GameObject;
            Rigidbody rocketRB = rocketInstance.GetComponent<Rigidbody>();
            rocketRB.AddForce(gameObject.transform.forward * bulletVelocity);

            //Instantiate(projectile, muzzle.transform.position, muzzle.transform.rotation);

            */
            //SashaGun();
            RiskyGun();

            //begin the Cooldown timer
            if (firingCooldown != 0)
            {
                canFire = false;
                StartCoroutine(StartCooldown());
            }
        }
    }
    private void SashaGun()
    {
        
        /*
        if(!fireSound.isPlaying)
        {
            fireSound.Play();
        }
        if(fireSound.isPlaying && !fireSoundAlt.isPlaying)
        {
            fireSoundAlt.Play();
        }
        */
        GameObject rocketInstance;
        Quaternion firingDirection = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 0));
        rocketInstance = BulletPool.Instance.SpawnFromPool(bulletType, muzzle.transform.position, Quaternion.identity) as GameObject;
        Rigidbody rocketRB = rocketInstance.GetComponent<Rigidbody>();
        rocketRB.AddForce(gameObject.transform.TransformDirection(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy), 1) * bulletVelocity);
        
    }

    private void RiskyGun()
    {
        GameObject rocketInstance;
        Quaternion firingDirection = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 0));
        rocketInstance = BulletPool.Instance.SpawnFromPool(bulletType, muzzle.transform.position, Quaternion.identity) as GameObject;
        Rigidbody rocketRB = rocketInstance.GetComponent<Rigidbody>();
        rocketRB.AddForce(gameObject.transform.TransformDirection(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy), 1) * bulletVelocity);
    }


    public void SetGunValues(float firerateVal, float bulletVelocityVal, float bulletSpreadVal, bool autoFireVal,
        string bulletTypeVal)
    {
        firingCooldown = firerateVal;
        bulletVelocity = bulletVelocityVal;
        accuracy = bulletSpreadVal;
        if (autoFireVal == true)
        {

        }
        bulletType = bulletTypeVal;
    }
    public void SetBulletType()
    {

    }
    IEnumerator StartCooldown()
    {
        
        yield return new WaitForSeconds(firingCooldown);
        
        canFire = true;
    }
}
