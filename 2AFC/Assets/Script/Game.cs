using System;

namespace JeuxVideal
{
    public class Game: Player
    {
        public (int, int) Degat(int dsubit, int PV, int defense)
        {
            if (defense > 0)
            {
                defense -= dsubit;
                if (defense < 0)
                {
                    PV = PV + defense;
                    defense = 0;
                    return (PV, defense);
                }
            }
            else
            {
                PV -= dsubit;
                if (PV < 0)
                {
                    PV = 0;
                }
            }

            return (PV, defense);
        }

        public bool IsAlive(int PV)
        {
            if (PV <= 0)
                return false;
            return true;
        }
    }
}