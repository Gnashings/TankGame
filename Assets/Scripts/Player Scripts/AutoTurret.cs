using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public BoxCollider shotBox;
    public AudioSource autoGunAudio;
    public ParticleSystem particlesfx;
    public float damage;
    public float cooldown;
    private bool canDamage;

    public List<AudioClip> audioShots;

    private void Start()
    {
        canDamage = true;
        particlesfx.Stop();
        autoGunAudio.clip = audioShots[Random.Range(0, audioShots.Count)];
    }

    private void OnTriggerStay(Collider other)
    {
        if(canDamage)
        {
            
            if (other.CompareTag("Enemy"))
            {
                particlesfx.Play();
                autoGunAudio.clip = audioShots[Random.Range(0, audioShots.Count)];
                autoGunAudio.Play();
                /*
                if (!autoGunAudio.isPlaying)
                {
                    autoGunAudio.clip = audioShots[Random.Range(0, audioShots.Count)];
                    autoGunAudio.Play();
                }*/
                other.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                canDamage = false;

                StartCoroutine(Damage());
            }
            else
                particlesfx.Stop();
        }

    }

    private IEnumerator Damage()
    {
        canDamage = false;
        yield return new WaitForSeconds(cooldown);
        canDamage = true;
    }
}
