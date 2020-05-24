using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Perte_de_vie : MonoBehaviour
{
    private int ZombiePV;
    TextMeshPro myText;

    private static Perte_de_vie instance;

    public static Perte_de_vie MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Perte_de_vie>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TextMeshPro>();
        ZombiePV = 100;
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "" + ZombiePV;
    }

    public void LooseHealth(int h)
    {
        ZombiePV -= h;
    }

    public bool IsZombieDead()
    {
        if(ZombiePV <= 0)
        {
            return true;
        }
        return false;
    }

    public int PV()
    {
        return ZombiePV;
    }
}
