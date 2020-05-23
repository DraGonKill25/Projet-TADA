using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDetroyMusic : MonoBehaviour
{
    public bool destroy;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (destroy || objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
