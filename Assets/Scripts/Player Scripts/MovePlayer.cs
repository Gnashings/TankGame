using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public PlayerInputControls inputs;
    private Rigidbody rb;
    public float speed;
    public float rotationSpeed;
    void Start()
    {
        inputs = gameObject.GetComponent<PlayerInputControls>();
        rb = gameObject.GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        //rb.position += Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetMoveForwardAxis() * speed * Time.deltaTime;

        rb.position += Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * inputs.GetPadMoveForwardAxis() * speed * Time.deltaTime;
        
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
        Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * Time.fixedDeltaTime * inputs.GetMoveRotationAxis());
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
