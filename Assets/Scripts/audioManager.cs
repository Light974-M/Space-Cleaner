using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSound;
    // Musique jouée in game
    public AudioClip music; 
    // Différents buitages joués
    [Header("Bruitages :")]
    public AudioClip x;
    public AudioClip buttonClic;
    public AudioClip z;

    void Start()
    {
        audioSourceMusic.clip = music;
        audioSourceMusic.Play();
    }

    public void PlaySong()
    {
        audioSourceSound.PlayOneShot(x);
    }

    public void PlayButton()
    {
        audioSourceSound.PlayOneShot(buttonClic);
    }
}