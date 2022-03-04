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
        speed = 0;
    }

    private void FixedUpdate()
    {
        //accel
        Move();
        Rotate();
    }
    public float acceleration;
    private void Move()
    {
        //rb.position += Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetMoveForwardAxis() * speed * Time.deltaTime;

        if(inputs.GetPadMoveForwardAxis().magnitude == 0)
        {
            //weird thing where you lose speed over time instead of instantly
            /*
            if(speed >= 0)
            {
                speed -= acceleration * Time.deltaTime;
            }
            */

            speed = 0;
            
        }
        if (speed >= topSpeed)
        {
            speed = topSpeed;
        }
        if (rb.velocity.magnitude <= topSpeed && inputs.GetPadMoveForwardAxis().magnitude != 0)
        {

            speed += acceleration * Time.deltaTime;

            rb.velocity = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetPadMoveForwardAxis() * speed;
        }
        
        //USE THIS IF ALL ELSE FAILS
        //rb.position += Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetPadMoveForwardAxis() * speed * Time.deltaTime;
        
    }

    private void Rotate()
    {
        Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * inputs.GetMoveRotationAxis());
        rb.MoveRotation(rb.rotation * deltaRotation);
    }


}
