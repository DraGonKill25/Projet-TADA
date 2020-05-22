using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perte_de_vie : MonoBehaviour
{
    private int ZombiePV;
    TextMesh myText;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TextMesh>();
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
}
