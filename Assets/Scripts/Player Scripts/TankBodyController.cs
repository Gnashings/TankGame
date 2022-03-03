using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// handles all rigidbody functionality for the tank
/// </summary>
public class TankBodyController : MonoBehaviour
{
    public PlayerInputControls inputs;
    private Rigidbody rb;
    public float speed;
    public float rotationSpeed;
    [HideInInspector]
    public float topSpeed;
    void Start()
    {
        inputs = gameObject.GetComponent<PlayerInputControls>();
        rb = gameObject.GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //og movement
        //Move();
        
    }

    private void FixedUpdate()
    {
        //accel
        Move();
        Rotate();
    }

    private void Move()
    {
        //rb.position += Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetMoveForwardAxis() * speed * Time.deltaTime;
        if(rb.velocity.magnitude <= topSpeed)
        {
            rb.AddForce(Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetPadMoveForwardAxis() * speed, ForceMode.Acceleration);
        }
        
        //USE THIS IF ALL ELSE FAILS
        //rb.position += Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetPadMoveForwardAxis() * speed * Time.deltaTime;
        
        /*
        if (inputs.gasPeddle)
        {
            Vector3 pog;
            pog.x = 0;
            pog.y = 0;
            pog.z = 1;
            Debug.Log(pog);
            rb.position += Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * pog * speed * Time.deltaTime;
        }*/

    }

    private void Rotate()
    {
        Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * inputs.GetMoveRotationAxis());
        rb.MoveRotation(rb.rotation * deltaRotation);
    }


}
