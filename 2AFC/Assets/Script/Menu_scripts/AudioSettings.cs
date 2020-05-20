using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMasterVolume (float volume)
    {
        audioMixer.SetFloat("mastervolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicvolume", volume);
    }

    public void SetEnvironmentVolume(float volume)
    {
        audioMixer.SetFloat("Environmentvolume", volume);
    }
}
