using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class PlayerHandler : MonoBehaviour
    {
        public PlayerStats Player;

        [SerializeField] private GameObject canvas;
        private bool displayCanvas;


        void Start()
        {
            canvas.gameObject.SetActive(false);
        }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("tab"))
            {
                if (canvas)
                {
                    displayCanvas = !displayCanvas;
                    canvas.SetActive(displayCanvas);
                }
            }
        }
    }
}
