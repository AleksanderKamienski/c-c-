using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6A
{

    class Wojsko
    {
        public ZolnierzZawodowy[] zolnierze
        {
            get;set;
        }
        bool[] zolnierze_;

        public Wojsko ( ZolnierzZawodowy[] _zolnierze)
        {
           

            zolnierze = new ZolnierzZawodowy[_zolnierze.Length];
            zolnierze_ = new bool[_zolnierze.Length];
            for (int i=0;i< _zolnierze.Length;++i)
            {
                Oficer o = new Oficer(0, "", "", 0, 0);
                Zolnierz z = new Zolnierz(0, "", "", "", 0);


                //shallow copy 
                //zolnierze[i] = _zolnierze[i];
                //deep copy (x.GetType() == typeof(Oficer))
                if (_zolnierze[i].GetType() == typeof(Oficer))
                {

                    o = (Oficer)_zolnierze[i];
                    zolnierze[i] = o.glebokakopia();
                }
                else if (_zolnierze[i].GetType() == typeof(Zolnierz))
                {
                    z = (Zolnierz)_zolnierze[i];
                    zolnierze[i] = z.glebokakopia();
                }

                zolnierze_[i] = true;

                    
            }
        }

        public List<ZolnierzZawodowy> JednostkiSpecjalne()
        {
            List<ZolnierzZawodowy> lista = new List<ZolnierzZawodowy>();
            Oficer o = new Oficer(0, "","",0,0);
            Zolnierz z = new Zolnierz(0, "", "","", 0);

            for (int i=0;i<zolnierze.Length;++i)
            {
                if(zolnierze[i].GetType() == typeof(Oficer))
                {
                    o = (Oficer)zolnierze[i];
                    if (o.ZmyslStrategiczny > 3 && o.ZnajomoscTerenu > 2)
                        lista.Add(zolnierze[i]);
                }
                else if (zolnierze[i].GetType() == typeof(Zolnierz))
                {
                    z = (Zolnierz)zolnierze[i];
                    if (z.Doswiadczenie =="duze"&& z.Amunicja > 99)
                        lista.Add(zolnierze[i]);
                }
            }
            return lista;
        }

        public List<Tuple<ZolnierzZawodowy, ZolnierzZawodowy>> SparujZolnierzy()
        {
            var TupleList = new List<Tuple<ZolnierzZawodowy, ZolnierzZawodowy>>
            { };

            for(int i =0;i<zolnierze.Length;++i)
            {
                for (int j= 0; j< zolnierze.Length; ++j)
                {
                    if(i!=j)
                    {
                        if (zolnierze[i].CzyMogeWspoldzialacZ(zolnierze[j])==true && zolnierze_[i]==true && zolnierze_[j]==true)
                        {
                            zolnierze_[i] = false;
                            zolnierze_[j] = false;
                            TupleList.Add(Tuple.Create(zolnierze[i], zolnierze[j]));
                        }
                     }
                }


            }

            return TupleList;

        }

    }
}
