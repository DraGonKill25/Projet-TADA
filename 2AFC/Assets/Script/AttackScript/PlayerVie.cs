using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVie : MonoBehaviour
{
    private int MyPlayerVie;
    TextMesh myText;

    void Start()
    {
        myText = GetComponent<TextMesh>();
        MyPlayerVie = 99;
    }

    void Update()
    {
        myText.text = " " + MyPlayerVie + "%";
    }

    public void LooseHealth(int h)
    {
        MyPlayerVie -= h;
    }
}
