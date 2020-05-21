using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider Slidermaster;
    public Slider Slidermusic;
    public Slider SliderEnvironment;

    public void Start()
    {
        Slidermaster.value = PlayerPrefs.GetFloat("mastervolume");
        Slidermusic.value = PlayerPrefs.GetFloat("musicvolume");
        SliderEnvironment.value = PlayerPrefs.GetFloat("Environmentvolume");
        audioMixer.SetFloat("mastervolume", PlayerPrefs.GetFloat("mastervolume"));
        audioMixer.SetFloat("musicvolume", PlayerPrefs.GetFloat("musicvolume"));
        audioMixer.SetFloat("Environmentvolume", PlayerPrefs.GetFloat("Environmentvolume"));
    }

    public void SetMasterVolume (float volume)
    {
        PlayerPrefs.SetFloat("mastervolume", volume);
        audioMixer.SetFloat("mastervolume", PlayerPrefs.GetFloat("mastervolume"));
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("musicvolume", volume);
        audioMixer.SetFloat("musicvolume", PlayerPrefs.GetFloat("musicvolume"));
    }

    public void SetEnvironmentVolume(float volume)
    {
        PlayerPrefs.SetFloat("Environmentvolume", volume);
        audioMixer.SetFloat("Environmentvolume", PlayerPrefs.GetFloat("Environmentvolume"));
    }
}
