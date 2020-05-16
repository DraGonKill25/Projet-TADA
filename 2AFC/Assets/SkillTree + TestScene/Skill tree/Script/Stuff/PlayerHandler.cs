﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class PlayerHandler : MonoBehaviour
    {
        public PlayerStats Player;

        [SerializeField] private Canvas canvas;
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
                    if (Cursor.visible == false)
                    {
                        Cursor.visible = true;
                    }
                    displayCanvas = !displayCanvas;
                    canvas.gameObject.SetActive(displayCanvas);
                }
                Cursor.visible = false;
            }
        }
    }
}
