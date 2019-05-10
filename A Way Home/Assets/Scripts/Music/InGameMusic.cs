using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _inGameMusic;

    public void ChangeMusic(AudioClip _music)
    { 
        _inGameMusic.Stop();
        _inGameMusic.clip = _music;
        _inGameMusic.Play();
    }
}
