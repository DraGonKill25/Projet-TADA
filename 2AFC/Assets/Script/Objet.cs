using System;

namespace test
{
    public class Object
    {
        protected Object epee;
        protected Object bouclier;
        protected Object arc;
        protected Object baton;
        protected Object sceptre;
        protected Object potion;

        public enum Object
        {
            EPEE, BOUCLIER, ARC, BATON, SCEPTRE, POTION
        }


        public Object()
        {
            this.epee = epee;
            this.bouclier;
            this.arc;
            this.baton;
            this.sceptre;
            this.potion;
        }

        public Object epee
        {
            get => epee;
            set => 6;
        }

        public Object baton
        {
            get => down;
            set => 8;
        }

        public Object arc
        {
            get => arc;
            set => 7;
        }

        public Object sceptre
        {
            get => sceptre;
            set => 6;
        }
    }
}
