using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    [System.Serializable]
    public class PlayerAttributes
    {
        public Attributes attributes;
        public int amount;

        public PlayerAttributes(Attributes attributes, int amount)
        {
            this.attributes = attributes;
            this.amount = amount;
        }
    }
}
