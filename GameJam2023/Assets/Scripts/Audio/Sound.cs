using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    [SerializeField] public AudioClip audioClip;

    //toggle for continuous music that turns off with a second click
    public bool loopAudio = false;
    public bool playOnStart = false;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public AudioMixerGroup mixerGroup;

    [HideInInspector] 
    public AudioSource m_AudioSource;


}



