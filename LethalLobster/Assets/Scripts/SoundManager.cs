using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    //Laver et array ud fra et script.

    public Sound[] sounds;

    //For at der kun kan k�rer en AudioManager.
    public static SoundManager Instance;

    public AudioMixer masterMixer;

    void Awake()
    {
        //For at sikre der kun k�rer en AuidoManager.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            //For at sikre at der ikke bliver kaldt mere kode f�r den er slettet.
            return;
        }

        //For at den ikke bliver slettet n�r scenerne skifter.
        DontDestroyOnLoad(gameObject);

        //Kalder vores Sound script og g�r s� de variabler ren faktisk g�r noget.
        foreach (Sound s in sounds)
        {
            //S� man kan finde hvor musikken er.
            s.sorce = gameObject.AddComponent<AudioSource>();
            s.sorce.clip = s.clip;

            //For at kunne �ndre volume, pitch og sp�rge om den skal v�re i et loop.
            s.sorce.volume = s.volume;
            s.sorce.pitch = s.pitch;
            s.sorce.loop = s.loop;

            AudioMixerGroup[] groups = masterMixer.FindMatchingGroups(s.mixerGroup);
            if (groups.Length > 0)
            {
                // Assign the first matching group to the outputAudioMixerGroup of the AudioSource
                s.sorce.outputAudioMixerGroup = groups[0];
            }
        }
    }

    void Start()
    {
        //Starter den der hedder "Theme" i vores array.

        //N�r man kalder den, tag og reference AudioManager f�r man ka spille lyden self:d
        Play("MainTheme");
    }


    //For at nemmere kunne kalde sounds igennem andre scipts, eller hvis man har mange sounds.
    public void Play(string name)
    {
        //Finder den sound med det samme man har skrevet ind i Play.
        Sound s = Array.Find(sounds, sound => sound.name == name);

        //Hvis man har skrevet forkert, s� fort�ller den det.
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found;(");
            //For at ikke blive ved at s�ge efter den sound.
            return;
        }
        //Starter den sound.
        s.sorce.Play();
    }


    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.sorce.Stop();
    }
}
