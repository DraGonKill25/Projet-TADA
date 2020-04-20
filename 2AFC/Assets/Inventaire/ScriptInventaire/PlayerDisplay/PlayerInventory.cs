using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptInventaire
{
    public class PlayerInventory : MonoBehaviour
    {
        [Header("Inventory")]
        public List<Object> Objet = new List<Object>();

        public List<Object> objet
        {
            get => Objet;
            set
            {
                Objet = value;
                if (numberOfObjectChange != null)
                    numberOfObjectChange();
            }
        }

        public delegate void NumberOfObjectChange();

        public event NumberOfObjectChange numberOfObjectChange;

        public void UpdateList(Object _objet,int Amount)
        {
            for (int i = 0; i < objet.Count; i++)
            {
                if (objet[i] == _objet)
                    objet[i].Amount += Amount;
            }
        }
    }
}
