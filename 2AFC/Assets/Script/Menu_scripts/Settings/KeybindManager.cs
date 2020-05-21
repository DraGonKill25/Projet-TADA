using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KeybindManager : MonoBehaviour
{
    private static KeybindManager instance;

    public static KeybindManager MyInstance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<KeybindManager>();
            }
            return instance;
        }
    }

    public Dictionary<string, KeyCode> Keybinds { get; private set; }

    private string bindName;

    // Start is called before the first frame update
    void Start()
    {
        Keybinds = new Dictionary<string, KeyCode>();

        BindKey("Forward", KeyCode.Z);
        BindKey("Back", KeyCode.S);
        BindKey("Left", KeyCode.Q);
        BindKey("Right", KeyCode.D);
        BindKey("Jump", KeyCode.Space);
        BindKey("Pause", KeyCode.Escape);
        BindKey("SkillTree", KeyCode.Tab);
        BindKey("Cursor", KeyCode.M);
        BindKey("Run", KeyCode.LeftShift);
        BindKey("Action_1", KeyCode.A);
        BindKey("Action_2", KeyCode.E);
        BindKey("Action_3", KeyCode.R);
        BindKey("Action_4", KeyCode.F);
    }

    public void BindKey(string key, KeyCode keyBind)
    {
        Dictionary<string, KeyCode> currentDictionary = Keybinds;

        if(!currentDictionary.ContainsKey(key))
        {
            currentDictionary.Add(key, keyBind);
            ManagerKeybinds.MyInstance.UpdateKeyText(key);
        }
        else if(currentDictionary.ContainsValue(keyBind))
        {
            string myKey = currentDictionary.FirstOrDefault(x => x.Value == keyBind).Key;

            currentDictionary[myKey] = KeyCode.None;
            ManagerKeybinds.MyInstance.UpdateKeyText(key);
        }

        currentDictionary[key] = keyBind;
        SaveKeys();
        ManagerKeybinds.MyInstance.UpdateKeyText(key);
        bindName = string.Empty;
    }

    public void KeyBindOnClick(string bindName)
    {
        this.bindName = bindName;
    }

    private void OnGUI()
    {
        if(bindName != string.Empty)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                BindKey(bindName, e.keyCode);
            }
        }
    }

    public void SaveKeys()
    {
        foreach(var key in Keybinds)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }
}
