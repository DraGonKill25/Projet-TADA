using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Script;

public class ViePerso : MonoBehaviour
{
    private int PV;
    [SerializeField]
    private TextMeshPro myText;
    private int saveMaxHP;
    public PlayerStats stat;

    //regen de vie
    public float CooldownTime = 10;
    private float nextcast = 0;    

    private static ViePerso instance;

    public static ViePerso MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ViePerso>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PV = stat.Attributes[0].amount;
        saveMaxHP = PV;
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "" + PV;

        if (stat.Attributes[0].amount < saveMaxHP)
        {
            PV = stat.Attributes[0].amount;
        }

        if(saveMaxHP < PV)
        {
            saveMaxHP = PV;
        }

        if (Time.time > nextcast && PV <saveMaxHP)
        {
            PV += 5;
            if(PV > saveMaxHP)
            {
                PV = saveMaxHP;
            }
            nextcast = Time.time + CooldownTime;
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
