using System;

namespace test
{
    public class Caracteristique : Object
    {
        protected int hp;
        protected int attaque;
        protected int atkS;
        protected int defense;
        


        public Caracteristique()
        {
            this.hp = 0;
            this.attaque = 0;
            this.atkS = 0;
            this.defense = 0;
        }


        public int HP
        {
            get { return hp; }
        }

        public int Attaque
        {
            get { return attaque; }
        }

        public int AtSp
        {
            get { return atkS; }
        }

        public int Defense
        {
            get { return defense; }
        }

        public (int, int, int, int) Parametre(int hp, int attaque, int atSp, int defense)
        {
            return (hp, attaque, atSp, defense);
        }

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

            PV -= dsubit;
            if (PV < 0)
            {
                PV = 0;
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