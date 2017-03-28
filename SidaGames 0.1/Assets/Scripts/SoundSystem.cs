using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {
    public static SoundSystem instance;
    public AudioSource audioSource;
    public AudioClip audioSalto;
    public AudioClip audioHit;
    public AudioClip audioDash;
    public AudioClip audioAccion;


    private void Awake()
    {
        if (SoundSystem.instance == null)
        {
            SoundSystem.instance = this;
        }else if (SoundSystem.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayJump()
    {
        PlayAudioClip(audioSalto);
    }
    public void PlayHit()
    {
        PlayAudioClip(audioHit);
    }
    public void PlayDash()
    {
        PlayAudioClip(audioDash);
    }
    public void PlayAccion()
    {
        PlayAudioClip(audioAccion);
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        if (SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        }
    }
}
