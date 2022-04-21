using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// handles all rigidbody functionality for the tank
/// </summary>
public class TankBodyController : MonoBehaviour
{
    public PlayerInputControls inputs;
    [HideInInspector]
    public Rigidbody rb;
    public float acceleration;
    public float speed;
    
    public float rotationSpeed;
    [HideInInspector]
    public float topSpeed;
    
    public bool ignoreAcceleration;
    private bool countingSlow;

    [Header("Slow Debuff")]
    [Tooltip("Do not go above 1")]
    public float slowAmount;
    public float slowDuration;
    public bool isSlowed;
    [HideInInspector]
    public bool slowImmune;
    public float backPenalty;
    
    void Start()
    {
        inputs = gameObject.GetComponent<PlayerInputControls>();
        rb = gameObject.GetComponentInChildren<Rigidbody>();
        speed = 0;
    }
    
    private void FixedUpdate()
    {
        if(isSlowed)
        {
            if(!countingSlow)
            {
                StartCoroutine(SlowTimer());
            }
        }
        Move();
        Rotate();
    }
    
    private void Move()
    {
        if (inputs.GetPadMoveForwardAxis().magnitude == 0)
        {
            /*weird thing where you lose speed over time instead of instantly
            if(speed > 0){speed -= acceleration * Time.deltaTime;}*/
            speed = 0;
        }
        if (inputs.GetPadMoveForwardAxis().magnitude != 0)
        {
            /*if(speed <= topSpeed) speed += acceleration * Time.deltaTime;
            rb.velocity = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetPadMoveForwardAxis() * speed * ForceSlow();*/
  
            CalculateMovementSpeed();
        }
        
        //USE THIS IF ALL ELSE FAILS
        //rb.position += Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetPadMoveForwardAxis() * speed * Time.deltaTime;
        
    }

    private void CalculateMovementSpeed()
    {

        if (rb.velocity.magnitude < topSpeed * BackPenalty() * ForceSlow())
        {
            if (!ignoreAcceleration)
            {
                if (speed <= topSpeed * BackPenalty() * ForceSlow()) speed += acceleration * Time.deltaTime;
            }
            else
            {
                speed = topSpeed * BackPenalty() * ForceSlow();
            }
            rb.velocity += Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetPadMoveForwardAxis() * speed * ForceSlow();
        }
    }

    private void Rotate()
    {
        Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * inputs.GetMoveRotationAxis());
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private float ForceSlow()
    {
        if (slowImmune)
        {
            return 1;
        }
        if(slowAmount < 0)
        {
            Debug.LogWarning("slowAmount is below 0, please set higher");
            return 1;
        }
        if(slowAmount > 1)
        {
            Debug.LogWarning("slowAmount is over 1, please set lower");
            return 1;
        }
        if (isSlowed)
        {
            return slowAmount;
        }
        else
            return 1;
    }
    private float BackPenalty()
    {
        if (inputs.GetPadMoveForwardAxis().z >= 0)
        {
            return 1;
        }
        else return backPenalty;
    }

    IEnumerator SlowTimer()
    {
        countingSlow = true;
        yield return new WaitForSeconds(slowDuration);
        countingSlow = false;
        isSlowed = false;
    }
}
