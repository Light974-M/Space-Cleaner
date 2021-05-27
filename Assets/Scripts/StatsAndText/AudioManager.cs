using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSound;
    // Musique jouée in game
    [Header("Musiques :")]
    public AudioClip musicLevel;
    public AudioClip musicMenu;
    // Différents buitages joués
    [Header("Bruitages :")]
    public AudioClip impact;
    public AudioClip buttonClic;
    public AudioClip winSound;
    public AudioClip garbageDepop;
    public AudioClip bulletTimeBegin;
    public AudioClip bulletTimeEnd;

    [Header("Dash :")]
    public AudioClip dashBegin;
    public AudioClip dash;
    public AudioClip dashEnd;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "tuto" | SceneManager.GetActiveScene().name == "Niveau")
        {
            audioSourceMusic.clip = musicLevel;
        }
        else if (SceneManager.GetActiveScene().name == "menu")
        {
            audioSourceMusic.clip = musicMenu;
        }
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

    public void PlayDepop()
    {
        audioSourceSound.PlayOneShot(garbageDepop);
    }

    public void PlayWin()
    {
        audioSourceSound.PlayOneShot(winSound);
    }

    public void PlayBulletTimeBegin()
    {
        Debug.Log("Begin");
        audioSourceSound.PlayOneShot(bulletTimeBegin);
    }
    public void PlayBulletTimeEnd()
    {
        Debug.Log("End");
        audioSourceSound.PlayOneShot(bulletTimeEnd);
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