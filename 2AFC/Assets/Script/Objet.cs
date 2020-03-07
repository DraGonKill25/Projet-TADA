using System;

namespace JeuxVideal
{
    public class Object
    {        
        public static readonly long[] POTION   = { 7 , 30 , 75  , 105 , 142 };

        private int lvl;

        public int Lvl
        {
            get { return lvl; }
        }

        public enum Objet
        {
            EPEE, BOUCLIER, ARC, BATON, SCEPTRE, POTION
        }

        protected Objet obj;

        public Objet Obj
        {
           get { return obj; } 
        }
    }
}
