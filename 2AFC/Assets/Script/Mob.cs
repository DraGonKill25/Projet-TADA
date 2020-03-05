using System;

namespace test
{
    public class Mobs : Caracteristique
    {
        protected Class classe;
        private Class mob_base;
        private Class B_5;
        private Class B_10;
        private Class B_15;


        public enum Class
        {
            mob_base, B_5, B_10, B_15
        }

        public Class GetClassM
        {
            get { return classe; }
        }

        public void Mob()
        {
            if (GetClassM == mob_base)
                Parametre(1, 1, 1, 1);

            if (GetClassM == B_5)
                Parametre(2, 2, 2, 2);

            if (GetClassM == B_10)
                Parametre(3, 3, 3, 3);

            if (GetClassM == B_15)
                Parametre(4, 4, 4, 4);
        }
    }
}