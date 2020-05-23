using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViePerso : MonoBehaviour
{
    private int PV;
    TextMesh myText;
    private int saveMaxHP;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TextMesh>();
        PV = 100;
        saveMaxHP = PV;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PV);
        myText.text = "" + PV;
        if(saveMaxHP < PV)
        {
            saveMaxHP = PV;
        }
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

    public int ReturnPV()
    {
        return PV;
    }

    public void ResetHP()
    {
        PV = saveMaxHP;
    }
}
