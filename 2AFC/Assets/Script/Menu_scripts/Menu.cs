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
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
