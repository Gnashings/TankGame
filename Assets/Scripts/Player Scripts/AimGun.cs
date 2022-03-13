using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    public PlayerInputControls inputs;
    void Start()
    {
        inputs = gameObject.GetComponentInParent<PlayerInputControls>();
    }

    void Update()
    {
        if(!PlayerProgress.paused)
        {
            PadAim();
        }
        
    }

    private void Aim()
    {
        //float cameraRot = Camera.main.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(inputs.GetLookAxis().y, inputs.GetLookAxis().x, 0);
    }

    private void PadAim()
    {
        //float cameraRot = Camera.main.transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, inputs.GetPadLookAxis() * Mathf.Rad2Deg, 0f); ;
    }
}
