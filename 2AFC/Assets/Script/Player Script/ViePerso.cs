using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViePerso : MonoBehaviour
{
    private int PV;
    TextMesh myText;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TextMesh>();
        PV = 100;
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "" + PV;
    }

    public void LooseHealth(int h)
    {
        PV -= h;
    }

    public bool IsMyPlayerDead()
    {
        if (PV <= 0)
        {
            return true;
        }
        return false;
    }
}
