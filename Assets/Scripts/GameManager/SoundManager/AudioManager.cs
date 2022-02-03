using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSound[] sounds;

    private void Awake()
    {
        foreach (AudioSound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("FactoryAmbiance");
    }
    public void Play(string name)
    {
        AudioSound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
