using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    private AudioSource Audio;

    public static SoundManager Sm;
    private void Awake()
    {
        Sm = this;
        Audio = GetComponent<AudioSource>();
    }
     
    public void brickTouchSound()
    {
        Audio.PlayOneShot(audio1);
    }
    public void levelIncreseSound()
    {
        Audio.PlayOneShot(audio2);
    }
    public void gameOverSound()
    {
        Audio.PlayOneShot(audio3);
    }
}
