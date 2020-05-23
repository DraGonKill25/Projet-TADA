using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Class
{
    [CreateAssetMenu(menuName = "RPG generator/player/Classe")]
    public class Class : ScriptableObject
    {
        public List<string> EvolutionMade;
        public string Name;

        private void OnEnable()
        {
            EvolutionMade = new List<string>{Name};
        }
    }
}