using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ManagerSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        KeybindManager.MyInstance.SaveKeys();

        audioMixer.SetFloat("mastervolume", PlayerPrefs.GetFloat("mastervolume"));
        audioMixer.SetFloat("musicvolume", PlayerPrefs.GetFloat("musicvolume"));
        audioMixer.SetFloat("Environmentvolume", PlayerPrefs.GetFloat("Environmentvolume"));

        Screen.fullScreen = (PlayerPrefs.GetInt("FullScreen") == 1);
        Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth"), PlayerPrefs.GetInt("ResolutionHeight"), Screen.fullScreen);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityIndex"));
    }
}
