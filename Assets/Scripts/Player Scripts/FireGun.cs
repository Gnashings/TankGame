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
    [Tooltip("Projectile to be shot")]
    public GameObject normalShot;
    public GameObject riskyBusiness;
    [Tooltip("Where to shoot projectile from")]
    public GameObject muzzle;

    //[HideInInspector]
    public float firingCooldown;
    public float bulletVelocity;
    private bool canFire;

    // Start is called before the first frame update
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
        FireTurret();
    }

    private void FireTurret()
    {
        if (inputs.Firing && canFire)
        {        
            GameObject rocketInstance;
            Quaternion firingDirection = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 0));
            rocketInstance = Instantiate(normalShot, muzzle.transform.position, firingDirection) as GameObject;
            Rigidbody rocketRB = rocketInstance.GetComponent<Rigidbody>();
            rocketRB.AddForce(gameObject.transform.forward * bulletVelocity);
            

            //Instantiate(projectile, muzzle.transform.position, muzzle.transform.rotation);

            //begin the Cooldown timer
            
            if(firingCooldown != 0)
            {
                canFire = false;
                StartCoroutine(StartCooldown());
            }
        }
    }

    IEnumerator StartCooldown()
    {
        
        yield return new WaitForSeconds(firingCooldown);
        
        canFire = true;
    }
}
