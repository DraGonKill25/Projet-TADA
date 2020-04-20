using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptInventaire
{
    [CreateAssetMenu(menuName = "RPG generator/player/Create Object")]
    public class Object : ScriptableObject
    {
        public string Description;
        public Sprite Icon;
        public int Amount;
        public void SetValue(GameObject objet)
        {
            if (objet)
            {
                ObjectDisplay DisplayComponent = objet.GetComponent<ObjectDisplay>();
                DisplayComponent.Name.text = name;
                
                if (DisplayComponent.Amount)
                    DisplayComponent.Amount.text = Amount.ToString();

                if (DisplayComponent.Icon)
                    DisplayComponent.Icon.sprite = Icon;

                /*if (DisplayComponent.Description)
                    DisplayComponent.Description.text = Description;*/
            }
        }
    }
}
