using System;


namespace JeuxVideal
{
    public class Epeiste : Player
    {
        public static readonly long[] UPGRADE_COST = { 5000, 10000, 45000 };
        public static readonly long[] ATTAQUE = { 22, 37, 60, 79 };
        public static readonly long[] DEFENSE = { 10, 20, 35, 50 };
        public static readonly long[] ATKS = { 17, 28, 40, 55 };
        public static readonly long[] HP = { 250, 512, 750, 1024 };
        public static readonly long[] EPEE = { 50, 75, 120, 150, 175 };
        public static readonly long[] BOUCLIER = { 15, 30, 60, 100, 750 };
        public static readonly long[] UPGRADE = { 0, 500, 2000, 5000, 10000 };

        private int lvl;

        public int Lvl
        {
            get { return Lvl; }
        }

        public Epeiste()
        {
            this.lvl = lvl;
            this.type = ClasseType.EPEISTE;
        }

        public long HP_E()
        {
            return HP[lvl];
        }

        public long Attaque_E()
        {
            return ATTAQUE[lvl];
        }

        public long Defense_E()
        {
            return DEFENSE[lvl];
        }

        public long Atks_E()
        {
            return ATKS[lvl];
        }

        public bool Upgrade(ref long money)
        {
            if (!(money < 5000 || Lvl >= 3))
            {
                if (Lvl == 0 && money >= 5000)
                {
                    money = money - UPGRADE_COST[0];
                    lvl++;
                    return true;
                }

                if (Lvl == 1 && money >= 10000)
                {
                    money = money - UPGRADE_COST[1];
                    lvl++;
                    return true;
                }

                if (Lvl == 2 && money >= 45000)
                {
                    money = money - UPGRADE_COST[2];
                    lvl++;
                    return true;
                }
            }
            return false;
        }
    }
}