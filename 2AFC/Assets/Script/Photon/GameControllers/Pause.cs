using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool paused = false;
    private bool disconnecting = false;

    public Animator transition;
    public float transitionTime = 1f;

    public void TogglePause()
    {
        if (disconnecting)
            return;

        Debug.Log("dans le toggle pause");
        paused = !paused;

        transform.GetChild(0).gameObject.SetActive(paused);
        Cursor.lockState = (paused) ? CursorLockMode.None : CursorLockMode.Confined;
        Cursor.visible = paused;
    }

    public void Quit()
    {
        disconnecting = true;
        StartCoroutine(DisconnectAndLoad(0));
    }

    IEnumerator DisconnectAndLoad(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        Debug.Log("Switching scene");
        SceneManager.LoadScene(levelIndex);
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
            yield return null;
    }
}
