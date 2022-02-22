using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireGun : MonoBehaviour
{
    public LayerMask IgnoreMe;
    public PlayerInputControls inputs;
    public GameObject projectile;
    public GameObject muzzle;

    Mouse mouse;
    // Start is called before the first frame update
    void Start()
    {
        inputs = gameObject.GetComponentInParent<PlayerInputControls>();

    }

    // Update is called once per frame
    void Update()
    {
        if(inputs.Firing)
        {
            GameObject rocketInstance;
            Quaternion spreadMid = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 0));
            rocketInstance = Instantiate(projectile, muzzle.transform.position, spreadMid) as GameObject;
            Rigidbody rocketRB = rocketInstance.GetComponent<Rigidbody>();
            rocketRB.AddForce(gameObject.transform.forward * 2000);
            //Instantiate(projectile, muzzle.transform.position, muzzle.transform.rotation);
        }
    }
}
