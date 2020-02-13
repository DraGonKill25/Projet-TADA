using System;
using Sort;

namespace Effect 
{
    public class Effet : Spell
    {
        public static readonly int[] MALEDICTION = { 0, 5, 10, 15, 20 };
        public static readonly int[] BENEDICTION = { 0, 5, 10, 15, 20 };
        protected Effet fire;
        protected Effet freeze;
        protected Effet stun;


        public Effet()
        {
            this.fire;
            this.freeze;
            this.stun;
        }


        public void CastEffect()
        {
            
        }
    }
}