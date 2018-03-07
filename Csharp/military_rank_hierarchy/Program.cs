using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace zad6A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Etap 1 ----");
            Oficer o1 = new Oficer(4, "Gromoslaw", "Kowalski", 3, 5);
            Oficer o2 = new Oficer(5, "Janusz", "Askiewicz", 5, 4);
            Oficer o3 = new Oficer(6, "Marian", "Nowak", 2, 3);

            o1.PrzedstawSie();
            o2.PrzedstawSie();
            o3.PrzedstawSie();

            Zolnierz zz1 = new Zolnierz(1, "Andrzej", "Mickiewicz", "zadne", 20);
            Zolnierz zz2 = new Zolnierz(2, "Julisz", "Slowacki", "male", 80);
            Zolnierz zz3 = new Zolnierz(3, "Tadeusz", "Krakiewicz", "duze", 130);
            Zolnierz zz4 = new Zolnierz(1, "Roman", "Grom", "male", 190);

            zz1.PrzedstawSie();
            zz2.PrzedstawSie();
            zz3.PrzedstawSie();
            zz4.PrzedstawSie();

            Console.WriteLine("---- Etap 2 ----");
            Console.WriteLine("Do zadan specjalnych melduja sie:");
            ZolnierzZawodowy[] zolnierze = { o1, zz1, o2, zz2, zz3, o3, zz4 };
            Wojsko wojsko = new Wojsko(  zolnierze);

            //tutaj wywolaj metode JednostkiSpecjalne() i "przedstaw" wszystkich zwroconych zolnierzy

            List<ZolnierzZawodowy> lista = wojsko.JednostkiSpecjalne();
            Oficer o = new Oficer(0, "", "", 0, 0);
            Zolnierz z = new Zolnierz(0, "", "", "", 0);

            foreach (ZolnierzZawodowy x in lista)
            {
                if (x is Oficer)
                {
                    o = (Oficer)x;
                    o.PrzedstawSie();
                }
                else if (x is Zolnierz)
                {
                    z = (Zolnierz)x;
                    z.PrzedstawSie();
                }


            }
            Console.WriteLine("---- Etap 3 ----");

            var TupleList = wojsko.SparujZolnierzy();
            int i = 1;
            foreach (var tuple in TupleList)
            {
                Console.WriteLine("Para {0} melduje sie na rozkaz  ", i);
                //tuple.Item1.PrzedstawSie();
                // tuple.Item2.PrzedstawSie();

                if (tuple.Item1 is Oficer)
                {
                    o = (Oficer)tuple.Item1;
                    o.PrzedstawSie();
                }
                else if (tuple.Item1 is Zolnierz)
                {
                    z = (Zolnierz)tuple.Item1;
                    z.PrzedstawSie();
                }



                if (tuple.Item2 is Oficer)
                {
                    o = (Oficer)tuple.Item2;
                    o.PrzedstawSie();
                }
                else if (tuple.Item2 is Zolnierz)
                {
                    z = (Zolnierz)tuple.Item2;
                    z.PrzedstawSie();
                }



                ++i;
            }
          

        }


    }
}


//O czym jest zadanie
//Zadanie będzie polegało na stworzeniu hierarchii klas, które reprezentują różnych żołnierzy,
//a następnie doborze ich w pary wg określonych kryteriów.

//Etap 1 (1.5 pkt.)
//Stwórz klasę ZolnierzZawodowy, która posiada:
//int stopien(pole tylko do odczytu), które będzie zawierało wartości od 1 do 6,
//oznaczające: 1-szeregowy, 2-kapral, 3-sierzant, 4-porucznik, 5-kapitan 6- major
//string Imie(pole tylko do odczytu)
//string Nazwisko(pole tylko do odczytu)
//metodę void PrzedstawSie(), która wypisuje na konsolę podstawowe informacje
//abstrakcyjną metodę bool CzyMogeWspoldzialacZ(ZolnierzZawodowy)
//konstruktor, który przyjmuje stopień, imie i nazwisko i po prostu przypisuje je do
//pól klasy.Zakładamy, że wszystkie dane zawsze będą podawane poprawnie
//(czyli stopień będzie z zakresu od 1 do 6).

//Stwórz klasę Zolnierz, która dziedziczy z ZolnierzZawodowy i posiada:
//string Doswiadczenie, które przyjmuje jedną z trzech wartości: zadne, male, duze
//int Amunicja
//metodę void PrzedstawSie(), która wywołuje metodę bazową, a następnie w kolejnej linii 
//informacje o doświadczeniu i amunicji
//Implementuje metodę bool CzyMogeWspoldzialacZ(ZolnierzZawodowy), na razie taką, że zwraca wartość true.
//Konstruktor, który przyjmuje stopień, imie, nazwisko, doswiadczenie i amunicje i po
//prostu przypisuje je do pól klasy.Zakładamy, że wszystkie dane zawsze będą podawane poprawnie.

//Stwórz klasę Oficer, która dziedziczy z ZolnierzZawodowy i posiada:
//int ZmyslStrategiczny
//int ZnajomoscTerenu
//metodę void PrzedstawSie(), która wywołuje metodę bazową, a następnie w kolejnej
//linii informacje o zmyśle strategicznym i znajomości terenu
//Implementuje metodę bool CzyMogeWspoldzialacZ(ZolnierzZawodowy), na razie taką, że zwraca wartość true.
//Konstruktor, który przyjmuje stopień, imie, nazwisko, zmysł strategiczny i znajomość
//terenu i po prostu przypisuje je do pól klasy. Zakładamy, że wszystkie dane zawsze będą podawane poprawnie.

//Etap 2 (1.5 pkt.)
//Stwórz klasę Wojsko:
//pole zolnierze, które jest tablicą przechowującą klasę ZolnierzZawodowy,
//konstruktor, który przyjmuje jako argument tablicę przechowującą klasę ZolnierzZawodowy i
//który dokonuje jej głębokiej kopii, którą przypisuje do pola zolnierze,
//JednostkiSpecjalne(), która zwraca listę zawierającą żołnierzy z pola zolnierze, takie że:
//Jeśli element jest Oficerem, to musi mieć zmysł strategiczny ≥ 4 i znajomość terenu ≥3
//Jeśli element jest Zolnierzem, to musi mieć duże doświadczenie i sztuk amunicji≥100
//Dodatkowo wywołaj tę metodę i wypisz elementy zwróconej listy w mainie.
//Lista liczb całkowitych w języku C# definiujemy następująco: List<int>. Aby dodać element na listę,
//a następnie wybrać dany element listy, można użyć następującego kodu:
//List<int> lista = new List<int>();
//lista.Add(5);
//lista.Add(4);
//lista.Add(7);
//int a = lista[0];
//int b = lista[2];
//int rozmiarListy = lista.Count;

//Etap 3 (2 pkt.)
//W klasie Zolnierz zaimplementuj bool CzyMogeWspoldzialacZ(ZolnierzZawodowy) w taki sposób,
//że(pisane z perspektywy żołnierza, na rzecz którego metoda jest wywoływana) :
//Jeśli argument jest Zolnierzem, to zwróć true wtedy i tylko wtedy, gdy wasze doświadczenie 
//jest takie samo, a także jeden z was ma niezerową ilość amunicji
//Jeśli argument jest Oficerem, to zwróć true wtedy i tylko wtedy, gdy: 
//jeśli nie masz żadnego doświadczenia, to gdy oficer ma zmysł strategiczny≥4
//jeśli twoje doświadczenie jest małe, to gdy oficer ma zmysł strategiczny ≥3
//jeśli twoje doświadczenie jest duże, to gdy oficer ma zmysł strategiczny≥1


//W klasie Oficer zaimplementuj bool CzyMogeWspoldzialacZ(ZolnierzZawodowy) w taki sposób, 
//że(pisane z perspektywy oficera, na rzecz którego metoda jest wywoływana) :
//Jeśli argument jest Zolnierzem, to zwróć true wtedy i tylko wtedy, gdy: 
//jeśli znasz teren na poziomie 4 i 5, to zaakceptujesz każdego żołnierza,
//jeśli znasz teren na poziomie 2-3 to zaakceptujesz kaprala i wyżej,
//jeśli jest on na poziomie 0-1, to tylko sierżantów.
//Jeśli argument jest Oficerem, to zwróć false

//W klasie Wojsko stwórz metodę SparujZolnierzy(), która zwraca listę krotek, gdzie w każdej 
//krotce znajdują się dwie instancje klasy ZolnierzZawodowy.Algorytm parowania żołnierzy jest 
//następujący: * Wybierz
//i-tego żołnierza.Sprawdź po kolei, od lewej do prawej w tablicy zolnierze, który żołnierz 
//jest taki, że pierwszy akceptuje drugiego, a drugi pierwszego (metodą CzyMogeWspoldzialacZ()).
//Dla pierwszego napotkanego w ten sposób żołnierza dodaj krotkę składającą się z nich dwóch na 
//listę.Oznacz ich w ten sposób, aby nie mogli już zostać wybrani w kolejnych iteracjach algorytmu.

//Dodatkowo wywołaj tę metodę i wypisz wszystkie pary w mainie.