using System;


namespace JeuxVideal
{
    public class Player : Object
    {
        public enum ClasseType
        {
            MAGE, EPEISTE, PRETRE, ARCHER
        }

        protected ClasseType type;

        public ClasseType Type
        {
            get { return type; }
        }
    }
}