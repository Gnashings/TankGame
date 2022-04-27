using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    
    public void SetLevel(float value)
    {
        mixer.SetFloat("TotalVolume", Mathf.Log10(value) * 20 ) ;
    }
}
