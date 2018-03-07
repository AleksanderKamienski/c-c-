using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6A
{
    
    class Oficer : ZolnierzZawodowy
    {
        public int ZmyslStrategiczny
        {
            get;
        }
        public int ZnajomoscTerenu
        {
            get;
        }
        override public ZolnierzZawodowy glebokakopia()
        {
            Oficer x = new Oficer(this.stopien, this.imie, this.nazwisko, this.ZmyslStrategiczny, this.ZnajomoscTerenu);
            ZolnierzZawodowy A = x;
            return A;
        }

        public Oficer(int _stopien, string _imie, string _nazwisko, int _ZmyslStrategiczny, int _ZnajomoscTerenu) : base(_stopien, _imie, _nazwisko)
        {
            ZmyslStrategiczny = _ZmyslStrategiczny;
            ZnajomoscTerenu = _ZnajomoscTerenu;
        }

        new public void PrzedstawSie()
        {
            base.PrzedstawSie();
            Console.WriteLine("Zmysl Strategiczny: {0} ", ZmyslStrategiczny + " ZnajomoscTerenu: " + ZnajomoscTerenu);

        }


        public override bool CzyMogeWspoldzialacZ(ZolnierzZawodowy x)
        {
            Oficer o = new Oficer(0, "", "", 0, 0);
            Zolnierz z = new Zolnierz(0, "", "", "", 0);


            //if (x is Oficer)
            //{
            //    o = (Oficer)x;
            //    if ((this.Doswiadczenie == "male" && o.ZmyslStrategiczny > 2) ||
            //      (this.Doswiadczenie == "zadne" && o.ZmyslStrategiczny > 3) ||
            //      (this.Doswiadczenie == "duze" && o.ZmyslStrategiczny > 0))
            //    {
            //        return true;
            //    }
            //}
            if (x.GetType() == typeof(Zolnierz))
            {
                z = (Zolnierz)x;
                if (this.ZnajomoscTerenu==4 || this.ZnajomoscTerenu == 5)
                {
                    return true;
                }
                else if((this.ZnajomoscTerenu == 2 || this.ZnajomoscTerenu == 3)&&
                        (z.stopien>1))
                {
                    return true;
                }
                else if ((this.ZnajomoscTerenu == 1 || this.ZnajomoscTerenu == 0)&&
                         (z.stopien == 3))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
