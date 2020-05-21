using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class ButtonUpgrade : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button someButton;
        public ItemsDisplay Player;


        void OnEnable()
        {
            //Register Button Events
            someButton.onClick.AddListener(() => ObjectToUpdate());

        }

        private void ObjectToUpdate()
        {
            if (Player.Upgradable())
            {
                Player.ChangeCost();
                Player.Player.item.Level += 1;
                Player.ChangeRessource();
                Player.Cost.text = ((int)Player.CostInInt).ToString();
                if (Player.Cost.text == "4242")
                    Player.Cost.text = "Level Max Atteint";
                Player.SetValue();
            }
        }

        void OnDisable()
        {
            //Un-Register Button Events
            someButton.onClick.RemoveAllListeners();
        }
    }
}