using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using ScriptInventaire;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class ItemsDisplay : MonoBehaviour
    {
        public Text ItemLevel;

        private bool ChangedClass;

        public Text Cost;

        public double CostInInt;

        public List<Image> Ressource;

        public Text TypeOfItem;

        public PlayerStats Player;

        public PlayerInventory PlayerInv;

        public Button Upgrade;

        public List<Image> Items;

        public Button Quit;

        public Canvas canvas;

        public Text Damage;

        public Text DamageAfter;

        //public int Cost;
        // Start is called before the first frame update
        void Start()
        {
            Player.item.Level = 1;
            ChangedClass = false;
            CostInInt = 1;
            Cost.text = CostInInt.ToString();
            Ressource[0].gameObject.SetActive(true);
            Ressource[1].gameObject.SetActive(false);
            Ressource[2].gameObject.SetActive(false);
            Ressource[3].gameObject.SetActive(false);

            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].gameObject.SetActive(false);
            }
            SetValue();
        }

        void Update()
        {
            if (Player.ChangedClass && !ChangedClass)
            {
                ChangedClass = true;
                if (Player.item.TypeOfItems == "Arc")
                    Items[0].gameObject.SetActive(true);
                else if (Player.item.TypeOfItems == "Epée")
                    Items[1].gameObject.SetActive(true);
                else if (Player.item.TypeOfItems == "Livre")
                    Items[2].gameObject.SetActive(true);
                else if (Player.item.TypeOfItems == "Chapeau")
                    Items[3].gameObject.SetActive(true);
                Player.item.Damage = 10;
                Player.item.DamageAfter = 5;
                SetValue();
            }
            
            Quit.onClick.AddListener(() =>
            {
                canvas.gameObject.SetActive(false);
            });
        }

        public void ChangeRessource()
        {
            if (Player.item.Level == 26)
            {
                Ressource[0].gameObject.SetActive(false);
                Ressource[1].gameObject.SetActive(true);
                Ressource[2].gameObject.SetActive(false);
                Ressource[3].gameObject.SetActive(false);
            }
            if (Player.item.Level == 51)
            {
                Ressource[0].gameObject.SetActive(false);
                Ressource[1].gameObject.SetActive(false);
                Ressource[2].gameObject.SetActive(true);
                Ressource[3].gameObject.SetActive(false);
            }
            if (Player.item.Level == 76)
            {
                Ressource[0].gameObject.SetActive(false);
                Ressource[1].gameObject.SetActive(false);
                Ressource[2].gameObject.SetActive(false);
                Ressource[3].gameObject.SetActive(true);
            }
            if (Player.item.Level == 100)
            {
                Ressource[0].gameObject.SetActive(false);
                Ressource[1].gameObject.SetActive(false);
                Ressource[2].gameObject.SetActive(false);
                Ressource[3].gameObject.SetActive(false);
                Player.item.DamageAfter = 0;
            }
        }

        public void ChangeCost()
        {
            if (Player.item.Level <= 25)
            {
                PlayerInv.Objet[0].Amount -= (int) CostInInt;
                CostInInt = Player.item.Level == 25 ? 1 : CostInInt*=1.2;
                Player.item.DamageAfter = Player.item.Level == 25
                    ? Player.item.DamageAfter = (int)(Player.item.DamageAfter / 2.5)
                    : Player.item.DamageAfter = Player.item.DamageAfter * 1.1;
            }

            if (Player.item.Level > 25 && Player.item.Level <= 50)
            {
                PlayerInv.Objet[1].Amount -= (int) CostInInt;
                CostInInt = Player.item.Level == 50 ? 1 : CostInInt*=1.23;
                Player.item.DamageAfter = Player.item.Level == 50
                    ? Player.item.DamageAfter = Player.item.DamageAfter / 2.5
                    : Player.item.DamageAfter = Player.item.DamageAfter * 1.11;
            }

            if (Player.item.Level > 50 && Player.item.Level <= 75)
            {
                PlayerInv.Objet[2].Amount -= (int) CostInInt;
                CostInInt = Player.item.Level == 75 ? 1 : CostInInt*=1.26;
                Player.item.DamageAfter = Player.item.Level == 75
                    ? Player.item.DamageAfter = Player.item.DamageAfter / 2.5
                    : Player.item.DamageAfter = Player.item.DamageAfter * 1.12;
            }

            if (Player.item.Level > 75 && Player.item.Level < 100)
            {
                PlayerInv.Objet[3].Amount -= (int) CostInInt;
                CostInInt = Player.item.Level == 99 ? 4242 : CostInInt*=1.29;
                Player.item.DamageAfter = Player.item.Level == 99
                    ? Player.item.DamageAfter = Player.item.DamageAfter / 2.5
                    : Player.item.DamageAfter = Player.item.DamageAfter * 1.13;
            }
        }

        public bool Upgradable()
        {
            if (Player.item.Level <= 25 && Player.item.Level>0)
            {
                return PlayerInv.Objet[0].Amount >= (int) CostInInt;
            }
            else if (Player.item.Level > 25 && Player.item.Level <= 50)
            {
                return PlayerInv.Objet[1].Amount >= (int) CostInInt;
            }
            else if (Player.item.Level > 50 && Player.item.Level <= 75)
            {
                return PlayerInv.Objet[2].Amount >= (int) CostInInt;
            }
            else if (Player.item.Level > 75 && Player.item.Level < 100)
            {
                return PlayerInv.Objet[3].Amount >= (int) CostInInt;
            }

            return false;
        }
        
        public void SetValue()
        {
            if (Player.item)
                Player.item.SetValue(this.gameObject);
        }
    }
}
