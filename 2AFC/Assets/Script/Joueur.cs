﻿using System;


namespace test
{
    public class Player : Caracteristique
    {
        protected Classe classe;

        private Classe mage;
        private Classe epeiste;
        private Classe pretre;
        private Classe archer;

        
        
        public enum Classe
        {
            mage, epeiste, pretre, archer
        }

        
        
        private Objet equipement;

        
        
       /* public void Equipement
        {
            get { return equipement; }
        }*/

        
        
        public Classe GetClasseP
        {
            get { return classe; }
        }
        
        
        /*public void WhichEquip(Classe perso)
        {
            testc = GetClasseP(perso);

            switch (perso)
            {
                case (mage):

            }
        }*/



        


        /*public Equipement(Classe perso)
        {
            
        }*/


        public void WitchClass()
        {
            if (GetClasseP == mage)
                Parametre(42, 20, 15, 25);

            if (GetClasseP == epeiste)
                Parametre(35, 22, 20, 35);

            if (GetClasseP == pretre)
                Parametre(55, 15, 10, 20);

            if (GetClasseP == archer)
                Parametre(45, 27, 25, 15);
        }
    }
}