using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Start()
    {
        Pause.paused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LaunchPlayGameMenu()
    {
        //PhotonNetwork.JoinRandomRoom();
        //PhotonNetwork.AutomaticallySyncScene = true;
        //PhotonNetwork.SendRate = 40; //Default 20
        //PhotonNetwork.SerializationRate = 40; //Default 10
        //PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.LoadLevel(2);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
