using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    public AudioLibrary audioLib;
    
    public AudioMixer mixer;

    public static AudioPlayer instance;

    // Start is called before the first frame update
    private void Start()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in audioLib.sounds)
        {
            s.m_AudioSource = gameObject.AddComponent<AudioSource>();
            s.m_AudioSource.clip = s.audioClip;
            s.m_AudioSource.volume = s.volume;
            s.m_AudioSource.pitch = s.pitch;

            s.m_AudioSource.loop = s.loopAudio;

            if (s.playOnStart == true)
            {
                s.m_AudioSource.Play();
            }

        }
    }

    public void SetMaster(float volume)
    {
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetMusic(float volume)
    {
        mixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    public void SetSFX(float volume)
    {
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void playAudio(string name)
    {
        foreach(Sound s in audioLib.sounds)
        {
            if (s.name == name)
            {
                s.m_AudioSource.Play();
            }
           
        if (s == null) return;
        
        }
        
    }
}