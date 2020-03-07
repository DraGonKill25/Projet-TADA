using System;

namespace JeuxVideal
{
    public class Spell : Player
    {
        public static readonly long[] ATTAQUE_BASE_MAGE = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_SECONDAIRE_MAGE = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_FORTE_MAGE = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_ULTIME_MAGE = { 0, 5, 10, 15, 20 };

        public static readonly long[] ATTAQUE_BASE_PRETRE = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_SECONDAIRE_PRETRE = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_FORTE_PRETRE = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_ULTIME_PRETRE = { 0, 5, 10, 15, 20 };

        public static readonly long[] ATTAQUE_BASE_EPEISTE = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_SECONDAIRE_EPEISTE = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_FORTE_EPEISTE = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_ULTIME_EPEISTE = { 0, 5, 10, 15, 20 };


        public static readonly long[] ATTAQUE_BASE_ARCHER = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_SECONDAIRE_ARCHER = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_FORTE_ARCHER = { 0, 5, 10, 15, 20 };
        public static readonly long[] ATTAQUE_ULTIME_ARCHER = { 0, 5, 10, 15, 20 };


        public enum ATKTYPE
        {
            BASE, SECONDAIRE, FORTE, ULTIME
        }

        private int lvl;

        protected ATKTYPE type;

        public ATKTYPE Type
        {
            get { return type; }
        }
    }
}