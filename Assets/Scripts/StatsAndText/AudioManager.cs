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
    public AudioClip impact;
    public AudioClip buttonClic;
    public AudioClip z;
    [Header("Dash :")]
    public AudioClip dashBegin;
    public AudioClip dash;
    public AudioClip dashEnd;

    void Start()
    {
        audioSourceMusic.clip = music;
        audioSourceMusic.Play();
    }

    public void PlayImpact()
    {
        audioSourceSound.PlayOneShot(impact);
    }

    public void PlayButton()
    {
        audioSourceSound.PlayOneShot(buttonClic);
    }

    IEnumerator DashCoroutine()
    {
        audioSourceSound.PlayOneShot(dashBegin);
        bool begin = true;
        yield return new WaitForSeconds(0.5f);
        while(begin)
        {
            audioSourceSound.PlayOneShot(dash);
            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                begin = false;
            }
        }
        audioSourceSound.PlayOneShot(dashEnd);
    }
}