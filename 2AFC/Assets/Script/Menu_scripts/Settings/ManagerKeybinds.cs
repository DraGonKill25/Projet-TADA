using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerKeybinds : MonoBehaviour
{
    private static ManagerKeybinds instance;

    public static ManagerKeybinds MyInstance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<ManagerKeybinds>();
            }

            return instance;
        }
    }

    private GameObject[] keybindButtons;

    private void Awake()
    {
        keybindButtons = GameObject.FindGameObjectsWithTag("Keybind");
    }

    public void UpdateKeyText(string key)
    {
        TextMeshProUGUI tmp = Array.Find(keybindButtons, x => x.name == key).GetComponentInChildren<TextMeshProUGUI>();
        tmp.text = PlayerPrefs.GetString(key);
    }
}
