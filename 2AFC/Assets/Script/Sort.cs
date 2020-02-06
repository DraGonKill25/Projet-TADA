using System;
using classeCarac;
using Joueur;

namespace Sort
{
    class Spell : Player
    {

        private int mb_level;
        public static readonly int[] MALEDICTION = { 0, 5, 10, 15, 20 };
        public static readonly int[] BENEDICTION = { 0, 5, 10, 15, 20 };


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



    }
}