using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Ins;
    [Range(0, 100)]
    public float musicVolume;
    [Range(0, 100)]
    public float soundVolume;
    public AudioSource musicAus;
    public AudioSource soundAus;
    public AudioClip[] backgroundMusics;
    public AudioClip rightSound;
    public AudioClip loseSound;
    public AudioClip winSound;
    // Start is called before the first frame update
    private void Awake()
    {
        MakeSingleton();
    }    
    void Start()
    {
        PlayBackgroundMusic();
    }
    private void Update()
    {
        if (musicAus && soundAus)
        {
            musicAus.volume = musicVolume;
            soundAus.volume = soundVolume;
        }
    }
    public void PlayBackgroundMusic()
    {
        if (musicAus && backgroundMusics != null && backgroundMusics.Length > 0)
        {
            int randIdx = Random.Range(0, backgroundMusics.Length);
            if (backgroundMusics[randIdx])
            {
                musicAus.clip = backgroundMusics[randIdx];
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }
    }
    public void PlaySound(AudioClip sound)
    {
        if (soundAus && sound)
        {
            soundAus.volume = soundVolume;
            soundAus.PlayOneShot(sound);
        }
    }
    public void PlayRightSound()
    {
        PlaySound(rightSound);
    }
    public void PlayLoseSound()
    {
        PlaySound(loseSound);
    }
    public void PlayWinSound()
    {
        PlaySound(winSound);
    }    
    // Update is called once per frame
    public void StopMusic()
    {
        if (musicAus)
        {
            musicAus.Stop();
        }
    }
    void MakeSingleton()
    {
        if (Ins == null)
        {
            Ins = this;
        }    
        else
        {
            Destroy(gameObject);
        }
    }

}
