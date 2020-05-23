using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptInventaire
{

    public class PlayerDisplay : MonoBehaviour
    {
        public Text Name;

        public Text MonsterPoint;
        
        public Text classe;
        [SerializeField] private PlayerStats Player;


        private void Start()
        {
            SetValues(Player);
        }

        private void Update()
        {
            SetValues(Player);
        }

        public void SetValues(PlayerStats Player)
        {
            if (Player)
            {
                Player = Player.GetComponent<PlayerStats>();
                Name.text = Player.PlayerName;

                MonsterPoint.text = Player.monsterPoint.ToString();

                classe.text = Player.classe.EvolutionMade[Player.classe.EvolutionMade.Count-1];
            }
        }
    }
}
