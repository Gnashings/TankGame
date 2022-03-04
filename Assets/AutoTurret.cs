using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public BoxCollider shotBox;
    public AudioSource autoGunAudio;
    public float damage;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("AUTOTURRET.CS NO ENEMY HEALTH IMPLIMENTED YET");
            
            if(!autoGunAudio.isPlaying)
            {
                autoGunAudio.Play();
            }
            //other.gameObject.SetActive(false);
        }
    }

}
