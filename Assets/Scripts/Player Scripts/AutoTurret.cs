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
            if(!autoGunAudio.isPlaying)
            {
                autoGunAudio.Play();
            }
            other.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
        }
    }

}
