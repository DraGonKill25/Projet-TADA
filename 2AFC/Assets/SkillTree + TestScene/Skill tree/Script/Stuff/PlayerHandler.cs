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
        [SerializeField]
        private PlayerStats stats;


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
                    if(stats.classe.Name == "Aventurier")
                    {
                        displayCanvas = !displayCanvas;

                        canvas.gameObject.transform.GetChild(0).gameObject.SetActive(displayCanvas);
                    }
                    if (stats.classe.Name == "Archer")
                    {
                        displayCanvas = !displayCanvas;

                        canvas.gameObject.transform.GetChild(1).gameObject.SetActive(displayCanvas);
                    }
                    if (stats.classe.Name == "Epéiste")
                    {
                        displayCanvas = !displayCanvas;

                        canvas.gameObject.transform.GetChild(4).gameObject.SetActive(displayCanvas);
                    }
                    if (stats.classe.Name == "Mage")
                    {
                        displayCanvas = !displayCanvas;

                        canvas.gameObject.transform.GetChild(3).gameObject.SetActive(displayCanvas);
                    }
                    if (stats.classe.Name == "Prêtre")
                    {
                        displayCanvas = !displayCanvas;

                        canvas.gameObject.transform.GetChild(2).gameObject.SetActive(displayCanvas);
                    }
                }
            }
        }
    }
}
