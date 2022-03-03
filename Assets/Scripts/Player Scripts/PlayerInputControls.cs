using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInputControls : MonoBehaviour
{
    private InputAction move;
    private InputAction gas;
    private InputAction look;
    private InputAction fire;
    private PlayerControls playerControls;
    public float sensitivity;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;
    private Vector3 direction;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Awake()
    {
        playerControls = new PlayerControls();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //RUMBLE IN THE JUNGLE
        /*
        if(direction.z != 0)
        {
            Gamepad.current.SetMotorSpeeds(0.20f, 0.20f);
        }
        else
            Gamepad.current.SetMotorSpeeds(0, 0);
        */

        //Debug.Log(GetMoveForwardAxis());
    }

    public bool Firing => fire.triggered;

    public Vector3 GetMoveForwardAxis()
    {
        direction.z = move.ReadValue<Vector2>().y;
        return direction;
    }

    public Vector3 GetMoveRotationAxis()
    {
        rotation.y = move.ReadValue<Vector2>().x;
        return rotation;
        
    }

    public Vector3 GetLookAxis()
    {
        //current code can be used for movement system
        currentRotation.x += look.ReadValue<Vector2>().x * sensitivity;
        currentRotation.y -= look.ReadValue<Vector2>().y * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle); 
        return currentRotation;
    }

    #region GAMEPAD
    Vector3 gamepadLook;
    float heading;
    public float GetPadLookAxis()
    {
        
        if (look.ReadValue<Vector2>().x!=0 && look.ReadValue<Vector2>().y !=0)
        {
            return heading = Mathf.Atan2(look.ReadValue<Vector2>().x, look.ReadValue<Vector2>().y);
        }
        
        return heading;
    }
    public Vector3 GetPadMoveForwardAxis()
    {
        Vector3 fw;
        fw.x = 0;
        fw.y = 0;
        fw.z = gas.ReadValue<Vector2>().y;
        return fw;
    }

    #endregion
    private void OnEnable()
    {
        
        move = playerControls.ScopeMode.Move;
        look = playerControls.ScopeMode.LookAround;
        fire = playerControls.ScopeMode.Fire;
        gas = playerControls.ScopeMode.Gas;

        move.Enable();
        look.Enable();
        fire.Enable();
        gas.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
        fire.Disable();
        gas.Enable();
    }
}
