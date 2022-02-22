using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScope : MonoBehaviour
{
    public PlayerInputControls inputs;
    public GameObject pivot;
    Vector3 newer;
    void Start()
    {
        inputs = gameObject.GetComponentInParent<PlayerInputControls>();
    }

    void Update()
    {
        PadAim();
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
