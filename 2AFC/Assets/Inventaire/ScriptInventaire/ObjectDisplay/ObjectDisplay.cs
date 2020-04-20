using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptInventaire
{
    public class ObjectDisplay : MonoBehaviour
    {
        public Object objet;
        public Text Name;
        //public Text Description;
        public Image Icon;
        public Text Amount;

        [SerializeField] private PlayerInventory PlayerHandler;
        void Start()
        {
            objet.Amount = 0;

            SetValues();
        }
        
        
        void Update()
        {
            SetValues();
        }


        void SetValues()
        {
            if (objet)
                objet.SetValue(this.gameObject);
        }
    }
}
