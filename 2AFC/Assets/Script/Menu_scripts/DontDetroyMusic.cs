using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDetroyMusic : MonoBehaviour
{
    public Scene multi;

    private void Awake()
    {
        Scene currScene = SceneManager.GetActiveScene();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1 || (currScene == multi))
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
