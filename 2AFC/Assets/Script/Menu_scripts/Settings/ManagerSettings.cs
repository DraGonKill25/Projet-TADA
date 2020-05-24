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
        PlayerPrefs.SetString("Forward", "Z");
        PlayerPrefs.SetString("Back", "S");
        PlayerPrefs.SetString("Left", "Q");
        PlayerPrefs.SetString("Right", "D");
        PlayerPrefs.SetString("Jump", "Space");
        PlayerPrefs.SetString("Pause", "Escape");
        PlayerPrefs.SetString("SkillTree", "Tab");
        PlayerPrefs.SetString("Cursor", "M");
        PlayerPrefs.SetString("Run", "LeftShift");
        PlayerPrefs.SetString("Action_1", "A");
        PlayerPrefs.SetString("Action_2", "E");
        PlayerPrefs.SetString("Action_3", "R");
        PlayerPrefs.SetString("Action_4", "F");
        PlayerPrefs.SetString("Accept", "O");
        PlayerPrefs.SetString("Refuse", "N");

        audioMixer.SetFloat("mastervolume", PlayerPrefs.GetFloat("mastervolume"));
        audioMixer.SetFloat("musicvolume", PlayerPrefs.GetFloat("musicvolume"));
        audioMixer.SetFloat("Environmentvolume", PlayerPrefs.GetFloat("Environmentvolume"));

        Screen.fullScreen = (PlayerPrefs.GetInt("FullScreen") == 1);
        Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth"), PlayerPrefs.GetInt("ResolutionHeight"), Screen.fullScreen);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityIndex"));
    }
}
