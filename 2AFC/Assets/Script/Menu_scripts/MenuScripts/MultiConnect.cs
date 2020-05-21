using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MultiConnect : MonoBehaviour
{
    [SerializeField]
    public GameObject _PlayMenuElementsUI;

    [SerializeField]
    public GameObject _MainMenuElementsUI;

    public void OnMultiButtonClicked()
    {
        _PlayMenuElementsUI.SetActive(false);
        SceneManager.LoadScene(1); //loadScene"playmutlti"
        _MainMenuElementsUI.SetActive(true);
    }
}
