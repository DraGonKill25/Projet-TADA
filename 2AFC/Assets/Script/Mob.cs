using System;

namespace JeuxVideal
{
    public class Mobs
    {
        public enum MobType
        {
            mob_base, B_5, B_10, B_15
        }

        protected MobType type;

        public MobType Type
        {
            get { return type; }
        }
    }
}