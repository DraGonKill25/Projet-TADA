using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateGardeVie : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro LeTxt;


    // Update is called once per frame
    void Update()
    {
        LeTxt.text = VieGARDE.MyInstance.PV().ToString();
    }
}
