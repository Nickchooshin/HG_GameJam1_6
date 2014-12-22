using UnityEngine;
using System.Collections;

public class AudioManager : MonoSingleton<AudioManager> {

    private AudioSource[] audioSource;

    public override void Init()
    {
        audioSource = gameObject.GetComponents<AudioSource>();
    }

    public void PlayBGM(AudioClip SEClip)
    {
        audioSource[0].clip = SEClip;
        audioSource[0].Play();
    }

    public void PlaySE(AudioClip SEClip)
    {
        audioSource[1].PlayOneShot(SEClip);
    }

    public void PlayVoice(AudioClip SEClip)
    {
        audioSource[2].PlayOneShot(SEClip);
    }

    public void StopBGM()
    {
        audioSource[0].Stop();
    }

    public void StopSE()
    {
        audioSource[1].Stop();
    }

    public void StopVoice()
    {
        audioSource[2].Stop();
    }
}
