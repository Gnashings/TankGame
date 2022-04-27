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
        //Debug.Log(inputs.MouseLookAxis() * Mathf.Rad2Deg);
        var (success, position) = inputs.MouseLookAxis();
        if(success)
        {
            var direction = position - transform.position;
            direction.y = 0;
            Debug.Log("SUCCESS" + direction);
            transform.forward = direction;
        }
    }

    private void PadAim()
    {
        //float cameraRot = Camera.main.transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, inputs.GetPadLookAxis() * Mathf.Rad2Deg, 0f); ;
    }
}
