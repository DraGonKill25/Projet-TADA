using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VieGARDE: MonoBehaviour
{
    private int GardePV;
    [SerializeField]
    private TextMeshPro myText;

    private static VieGARDE instance;

    public static VieGARDE MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<VieGARDE>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GardePV = 100;
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = PV().ToString();
    }

    public void LooseHealth(int h)
    {
        GardePV -= h;
    }

    public bool IsZombieDead()
    {
        if (GardePV <= 0)
        {
            return true;
        }
        return false;
    }

    public int PV()
    {
        return GardePV;
    }
}
