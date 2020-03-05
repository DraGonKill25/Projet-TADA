using System;

namespace test
{
    public class Object
    {
        protected Objet epee;
        protected Objet bouclier;
        protected Objet arc;
        protected Objet baton;
        protected Objet sceptre;
        protected Objet potion;

        public enum Objet
        {
            EPEE, BOUCLIER, ARC, BATON, SCEPTRE, POTION
        }


        public Object()
        {
            this.epee = epee;
            this.bouclier=bouclier;
            this.arc = arc;
            this.baton=baton;
            this.sceptre=sceptre;
            this.potion=potion;
        }

        /*public Objet Epee
        {
            get => epee;
            set => 6;
        }

        public Objet Baton
        {
            get => baton;
            set => 8;
        }

        public Objet Arc
        {
            get => arc;
            set => 7;
        }

        public Objet Sceptre
        {
            get => sceptre;
            set => 6;
        }*/
    }
}
