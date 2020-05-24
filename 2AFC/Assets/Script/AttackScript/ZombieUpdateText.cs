using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieUpdateText : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro LeTxt;


    // Update is called once per frame
    void Update()
    {
        LeTxt.text = Perte_de_vie.MyInstance.PV().ToString();
    }
}
