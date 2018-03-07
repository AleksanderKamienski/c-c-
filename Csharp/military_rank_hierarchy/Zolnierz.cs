using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6A
{
    
    class Zolnierz : ZolnierzZawodowy
    {
        public int Amunicja
        {
            get;
        }
        public string Doswiadczenie
        {
            get;
        }

        public Zolnierz(int _stopien, string _imie, string _nazwisko, string _doswiadczenie, int _amunicja ): base(_stopien, _imie, _nazwisko )
        {
            Amunicja = _amunicja;
            Doswiadczenie = _doswiadczenie;
        }

        override public ZolnierzZawodowy glebokakopia()
        {
            Zolnierz x = new Zolnierz(this.stopien, this.imie, this.nazwisko, this.Doswiadczenie, this.Amunicja);
            ZolnierzZawodowy A = x;
            return A;
        }

        new public void PrzedstawSie()
        {
            base.PrzedstawSie();
            Console.WriteLine("ilosc amunicji: {0} ", Amunicja + " Doswiadczenie: " + Doswiadczenie);

        }
        public override bool CzyMogeWspoldzialacZ(ZolnierzZawodowy x)
        {
            Oficer o = new Oficer(0, "", "", 0, 0);
            Zolnierz z = new Zolnierz(0, "", "", "", 0);

            
            if (x.GetType() == typeof(Oficer))
            {
                o = (Oficer)x;
                if((this.Doswiadczenie == "male" && o.ZmyslStrategiczny>2)||
                  (this.Doswiadczenie == "zadne" && o.ZmyslStrategiczny > 3)||
                  (this.Doswiadczenie == "duze" && o.ZmyslStrategiczny > 0))
                {
                    return true;
                }
            }
            else if (x.GetType() == typeof(Zolnierz))
            {
                z = (Zolnierz)x;
                if(z.Doswiadczenie == this.Doswiadczenie && (z.Amunicja>0 || this.Amunicja>0))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
