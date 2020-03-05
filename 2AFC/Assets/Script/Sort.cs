using System;

namespace test
{
    public class Spell : Player
    {
        public static readonly int[] MALEDICTION = { 0, 5, 10, 15, 20 };
        public static readonly int[] BENEDICTION = { 0, 5, 10, 15, 20 };
        private int mb_level;
       

        public Spell()
        {
            this.mb_level = 0;
        }


        public int Mb_level
        {
            get { return mb_level; }
        }


        public int Malediciton(int timer)
        {
            return attaque * (1 - MALEDICTION[mb_level]);
        }
        
        /*public void Attaque_de_base()
        {
            if (Player.GetClassP == archer)
            {

            }
        }*/

    }
}























/*
namespace Effect
{
    class Effet : Spell
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
    }   
}*/
