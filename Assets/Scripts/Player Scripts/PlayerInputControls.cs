using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerInputControls : MonoBehaviour
{
    private InputAction move;
    private InputAction gas;
    private InputAction look;
    private InputAction fire;
    private InputAction pause;
    private InputAction gadget;
    private PlayerControls playerControls;
    public float sensitivity;
    [HideInInspector]
    public float maxYAngle = 80f;
    private Vector2 currentRotation;
    private Vector3 direction;
    private Vector3 rotation;
    private bool gadgetSet;

    // Start is called before the first frame update
    void Awake()
    {
        playerControls = new PlayerControls();
        LockMouse();
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
    }

    public bool Firing => fire.triggered;
    public bool paused => pause.triggered;

    public bool gadgetStart => gadget.triggered;
    [HideInInspector]
    public bool isHeld;

    public bool IsFireHeld()
    {
        fire.canceled += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                isHeld = false;
            }
        };
        fire.started += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                isHeld = true;
            }         
        };

        return isHeld;
    }

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

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        pause = playerControls.ScopeMode.Pause;
        gadget = playerControls.ScopeMode.Gadget;
        gadget.Enable();
        move.Enable();
        look.Enable();
        fire.Enable();
        gas.Enable();
        pause.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
        fire.Disable();
        gas.Disable();
        pause.Disable();
        gadget.Disable();
    }
}
