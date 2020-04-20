using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptInventaire
{
    public class ButtonTest : MonoBehaviour
    {
        public Button someButton;
        public Object objet;
        public int Amount;
        public PlayerInventory Player;


        void OnEnable()
        {
            //Register Button Events
            someButton.onClick.AddListener(() => ObjectToUpdate());
            
        }

        private void ObjectToUpdate()
        {
            for (int i = 0; i < Player.objet.Count; i++)
            {
                if (Player.objet[i] == objet)
                    Player.objet[i].Amount += Amount;
            }
        }

        void OnDisable()
        {
            //Un-Register Button Events
            someButton.onClick.RemoveAllListeners();
        }
    }
}
