using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoSettings : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown resolutionDropDown;
    public Dropdown qualityDropDown;
    public TextMeshProUGUI currquality;
    public Toggle fullscreen;

    public static string[] optionsQualities = new string[] { "Very Low", "Low", "Medium", "High", "Very High" };

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> optionsResolutions = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            optionsResolutions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        fullscreen.isOn = (PlayerPrefs.GetInt("FullScreen") == 1);

        currquality.text = optionsQualities[QualitySettings.GetQualityLevel()];

        resolutionDropDown.AddOptions(optionsResolutions);
        PlayerPrefs.SetInt("ResolutionIndex", currentResolutionIndex);
        resolutionDropDown.value = PlayerPrefs.GetInt("ResolutionIndex");
        resolutionDropDown.RefreshShownValue();

        qualityDropDown.value = PlayerPrefs.GetInt("QualityIndex");
        qualityDropDown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        PlayerPrefs.SetInt("ResolutionWidth", resolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
        Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth"), PlayerPrefs.GetInt("ResolutionHeight"), Screen.fullScreen);
    }

    public void SetQuality (int qualityIndex)
    {
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityIndex"));
        currquality.text = optionsQualities[QualitySettings.GetQualityLevel()];
        qualityDropDown.value = PlayerPrefs.GetInt("QualityIndex");
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = (PlayerPrefs.GetInt("FullScreen") == 1);
        PlayerPrefs.SetInt("FullScreen", (isFullScreen ? 1 : 0));
        fullscreen.isOn = (PlayerPrefs.GetInt("FullScreen") == 1);
    }
}
