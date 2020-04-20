using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptInventaire
{
    public class PlayerHandler : MonoBehaviour
    {
        public PlayerInventory Player;

        [SerializeField] private Canvas canvas;

        private void Start()
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
