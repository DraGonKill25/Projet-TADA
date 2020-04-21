using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Script
{
    public class PlayerStats : MonoBehaviour
    {

        [Header("Player stats")]
        public string PlayerName;
        [SerializeField]
        private int MonsterPoint = 0;

        public int monsterPoint
        {
            get { return MonsterPoint; }
            set
            {
                MonsterPoint = value;
                if (monsterPointChange != null)
                    monsterPointChange();
            }
        }

        [Header("Player attributes")]
        public List<PlayerAttributes> Attributes = new List<PlayerAttributes>();
        
        [Header("Player Skills")]
        public List<Skills> Skills = new List<Skills>();

        public delegate void MonsterPointChange();

        public event MonsterPointChange monsterPointChange;

        public void UpdatePoint(int amount)
        {
            monsterPoint += amount;
        }

        void Start()
        {
            PlayerName = GetComponent<PhotonView>().Owner.NickName;
        }
    }
}
