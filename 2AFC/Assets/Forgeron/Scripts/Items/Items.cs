using System.Collections;
using System.Collections.Generic;
using ScriptInventaire;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Items
{
    [CreateAssetMenu(menuName = "RPG generator/player/Create Items")]
    public class Items : ScriptableObject
    {
        public string Description;
        public int Damage;
        public string TypeOfItems;
        public int Level;
        public double DamageAfter;
        
        public void SetValue(GameObject items)
        {
            if (items)
            {
                ItemsDisplay DisplayComponent = items.GetComponent<ItemsDisplay>();

                if (DisplayComponent.TypeOfItem)
                    DisplayComponent.TypeOfItem.text = TypeOfItems;

                if (DisplayComponent.ItemLevel)
                    DisplayComponent.ItemLevel.text = "Level "+Level.ToString();

                if (DisplayComponent.Damage)
                    DisplayComponent.Damage.text = Damage.ToString() + " Dégats";

                if (DisplayComponent.DamageAfter)
                    DisplayComponent.DamageAfter.text = "+ " + ((int)DamageAfter).ToString();

                Damage += (int)DamageAfter;
            }
        }
    }
}
