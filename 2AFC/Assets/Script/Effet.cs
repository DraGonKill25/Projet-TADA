using System;

namespace JeuxVideal 
{
    public class Effet : Player
    {
        public static readonly int[] MALEDICTION = { 0, 5, 10, 15, 20 };
        public static readonly int[] BENEDICTION = { 0, 5, 10, 15, 20 };
        protected bool fire;
        protected bool freeze;
        protected bool stun;

        /*public bool Fire()
        {
        }*/
    }
}