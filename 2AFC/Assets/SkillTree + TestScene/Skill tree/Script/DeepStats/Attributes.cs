using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    [CreateAssetMenu(menuName = "RPG generator/player/Create Attribute")]
    public class Attributes : ScriptableObject
    {
        public string Description;
        public Sprite Icon;
    }
}
