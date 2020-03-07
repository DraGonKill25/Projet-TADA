using System;


namespace JeuxVideal
{
    public class Archer : Player
    {
        public static readonly long[] UPGRADE_COST = { 5000, 10000, 45000 };
        public static readonly long[] ATTAQUE = { 25, 38, 60, 85 };
        public static readonly long[] DEFENSE = { 10, 20, 35, 50 };
        public static readonly long[] ATKS = { 18, 26, 40, 55 };
        public static readonly long[] HP = { 200, 450, 710, 892 };
        public static readonly long[] ARC = { 62, 85, 145, 166, 180 };
        public static readonly long[] UPGRADE_ARME = { 0, 500, 2000, 5000, 10000 };

        private int lvl;

        public int Lvl
        {
            get { return Lvl; }
        }

        public Archer()
        {
            this.lvl = lvl;
            this.type = ClasseType.ARCHER;
        }

        public long HP_A()
        {
            return HP[lvl];
        }

        public long Attaque_A()
        {
            return ATTAQUE[lvl];
        }

        public long Defense_A()
        {
            return DEFENSE[lvl];
        }

        public long Atks_A()
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