using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace zad6A
{
    
    abstract class ZolnierzZawodowy
    {
        public int stopien
        {
            get;
        }
        public string imie
        {
            get;
        }
        public string nazwisko
        {
            get;
        }

        abstract public ZolnierzZawodowy glebokakopia();
        
            

        

        public ZolnierzZawodowy(int _stopien, string _imie, string _nazwisko)
        {
            stopien = _stopien;
            imie = _imie;
            nazwisko = _nazwisko;
        }
        public void PrzedstawSie()
        {
            string pagon = "";
            if (stopien == 1)
                pagon = "szeregowy";
            if (stopien == 2)
                pagon = "kapral";
            if (stopien == 3)
                pagon = "sierzant";
            if (stopien == 4)
                pagon = "porucznik";
            if (stopien == 5)
                pagon = "kapitan";
            if (stopien == 6)
                pagon = "major";


            Console.WriteLine("stopień :"+pagon+ " imie: " + imie + " nazwisko: "+ nazwisko); 
        }

        public abstract bool CzyMogeWspoldzialacZ(ZolnierzZawodowy x);
        

    }
}
