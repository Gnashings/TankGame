using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 newtrans;

    // Start is called before the first frame update
    void Start()
    {
        offset.x = transform.position.x - player.transform.position.x;
        offset.z = transform.position.z - player.transform.position.z;
        newtrans = transform.position;
        //not taking y as we won't update y position. 

    }
    void LateUpdate()
    {
        newtrans.x = player.transform.position.x + offset.x;
        newtrans.z = player.transform.position.z + offset.z;
        transform.position = newtrans;
    }
}
