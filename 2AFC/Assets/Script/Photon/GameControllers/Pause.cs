using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool paused = false;
    private bool disconnecting = false;

    public void TogglePause()
    {
        if (disconnecting)
            return;

        Debug.Log("dans le toggle pause");
        paused = !paused;

        transform.GetChild(0).gameObject.SetActive(paused);
        Cursor.lockState = (paused) ? CursorLockMode.None : CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void Quit()
    {
        disconnecting = true;
        SceneManager.LoadScene(0);
        PhotonNetwork.Disconnect();
    }
}
