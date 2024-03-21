using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    //Giver den en r�kke forskellige ting man kan �ndre ved i AudioManageren.
    public string name;

    //Kan uploaded clippet.
    public AudioClip clip;

    //�ndre volumen mellem en hvis range.
    [Range(0f, 1f)]
    public float volume;

    //�ndre pitchen mellem en hvis range.
    [Range(0.1f, 3f)]
    public float pitch;

    //S� man kan loop musikken
    public bool loop;

    //public AudioMixer audioMixer;
    public string mixerGroup;

    //Skal ikke vises i inspectoren
    [HideInInspector]
    public AudioSource sorce;
}
