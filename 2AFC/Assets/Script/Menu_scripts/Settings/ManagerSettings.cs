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
        KeybindManager.MyInstance.BindKey("Forward", KeyCode.Z);
        KeybindManager.MyInstance.BindKey("Back", KeyCode.S);
        KeybindManager.MyInstance.BindKey("Left", KeyCode.Q);
        KeybindManager.MyInstance.BindKey("Right", KeyCode.D);
        KeybindManager.MyInstance.BindKey("Jump", KeyCode.Space);
        KeybindManager.MyInstance.BindKey("Pause", KeyCode.Escape);
        KeybindManager.MyInstance.BindKey("SkillTree", KeyCode.Tab);
        KeybindManager.MyInstance.BindKey("Cursor", KeyCode.M);
        KeybindManager.MyInstance.BindKey("Run", KeyCode.LeftShift);
        KeybindManager.MyInstance.BindKey("Action_1", KeyCode.A);
        KeybindManager.MyInstance.BindKey("Action_2", KeyCode.E);
        KeybindManager.MyInstance.BindKey("Action_3", KeyCode.R);
        KeybindManager.MyInstance.BindKey("Action_4", KeyCode.F);
        KeybindManager.MyInstance.BindKey("Accept", KeyCode.O);
        KeybindManager.MyInstance.BindKey("Refuse", KeyCode.N);

        audioMixer.SetFloat("mastervolume", PlayerPrefs.GetFloat("mastervolume"));
        audioMixer.SetFloat("musicvolume", PlayerPrefs.GetFloat("musicvolume"));
        audioMixer.SetFloat("Environmentvolume", PlayerPrefs.GetFloat("Environmentvolume"));

        Screen.fullScreen = (PlayerPrefs.GetInt("FullScreen") == 1);
        Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth"), PlayerPrefs.GetInt("ResolutionHeight"), Screen.fullScreen);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityIndex"));
    }
}
