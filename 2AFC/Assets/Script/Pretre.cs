using System;


namespace JeuxVideal
{
    public class Pretre : Player
    {
        public static readonly long[] UPGRADE_COST = { 5000, 10000, 45000 };
        public static readonly long[] ATTAQUE = { 15, 30, 55, 70 };
        public static readonly long[] DEFENSE = { 10, 20, 35, 50 };
        public static readonly long[] ATKS = { 15, 23, 36, 50};
        public static readonly long[] HP = { 250, 512, 750, 1024 };
        public static readonly long[] SCEPTRE = { 42, 66, 72, 100, 152 };
        public static readonly long[] UPGRADE = { 0, 500, 2000, 5000, 10000 };

        private int lvl;

        public int Lvl
        {
            get { return Lvl; }
        }

        public Pretre()
        {
            this.lvl = lvl;
            this.type = ClasseType.PRETRE;
        }

        public long HP_P()
        {
            return HP[lvl];
        }

        public long Attaque_P()
        {
            return ATTAQUE[lvl];
        }

        public long Defense_P()
        {
            return DEFENSE[lvl];
        }

        public long Atks_P()
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