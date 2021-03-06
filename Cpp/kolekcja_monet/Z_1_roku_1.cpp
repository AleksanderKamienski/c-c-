#include "Numizmat.h"
#include "Zbior.h"
#include <iostream>
#include <ctime>
#include <cstdlib>

using namespace std;

int main()
{


	cout << endl;
	cout << "*********************** ETAP 1 (0.5 pkt) *********************** " << endl << endl;

	
	Numizmat m1(3, 1661, "Szelag - Boratynka");
	Numizmat m2(73, 1622, "Szostak Jana Kazimierza Wazy");
	Numizmat m3(7, 1661, "Szelag - Boratynka");

	cout << "Moneta 1: " << m1 << endl << "Moneta 2: " << m2 << endl << "Moneta 3: " << m3 << endl << endl;
	if (m1 == m3) cout << "Monety 1 i 3 takie same" << endl << endl;
	else cout << "Monety 1 i 3 rozne - blad operatora" << endl << endl;


	cout << "*********************** ETAP 2 (1.5 pkt) *********************** " << endl << endl;

	Zbior kol1;
	cout << kol1 << endl;

	kol1.dodaj_do_kolekcji(m1);
	kol1.dodaj_do_kolekcji(m2);
	kol1.dodaj_do_kolekcji(m3);
	cout << "Kolekcja monet I Rzeczypospolitej:" << endl;
	cout << kol1;

	cout << "Wartosc kolekcji: " << kol1.wartosc_kolekcji() << " zl" << endl << endl;

	cout << "Z kolekcji wyjeto monete " << kol1.wyjmij() << endl << endl;
	cout << kol1;
	cout << "Wartosc kolekcji: " << kol1.wartosc_kolekcji() << " zl" << endl << endl;

	cout << "*********************** ETAP 3 (2.0 pkt) *********************** " << endl << endl;
	
	Zbior kol2;
	kol2.wczytaj_z_pliku("20_lecie_miedzywojenne.txt");
	cout << "Kolekcja monet 20-lecia miedzywojennego:" << endl;
	cout << kol2;
	cout << "Wartosc kolekcji: " << kol2.wartosc_kolekcji() << " zl" << endl << endl;

	cout << "*********************** ETAP 4 (2.0 pkt) *********************** " << endl << endl;
	
	list<Numizmat> lista_duplikatow;
	lista_duplikatow = kol2.przenies_duplikaty();
	kol1.dodaj_do_kolekcji(lista_duplikatow);
	cout << "Duplikaty i I Rzeczpospolita:" << endl;
	cout << kol1;
	cout << "Wartosc kolekcji: " << kol1.wartosc_kolekcji() << " zl" << endl << endl;
	//cout << kol2;

	cout << "*********************** ETAP 5 (2.0 pkt) *********************** " << endl << endl;
	
	kol2.uloz_rocznikami();
	cout << "Kolekcja posortowana latami:" << endl;
	cout << kol2 << endl;

	kol2.sprzedaj(500);
	cout << "Kolekcja po sprzedazy monet:" << endl;
	cout << kol2;
	cout << "Wartosc kolekcji: " << kol2.wartosc_kolekcji() << " zl" << endl << endl;

	cout << "I bardzo dobrze Kolekcjoner zrobil sprzedajac monety," << endl;
	cout << "bo oto pojawil sie zlodziej, ktory ukradl polowe kolekcji." << endl;
	cout << "A ze nie znal sie na numizmatyce, to zabral na chybil trafil." << endl;
	cout << "W sumie, ludzki zlodziej - mogl zabrac wszystko :)" << endl << endl;

	int ilosc_monet = kol2.ile_monet();
	for (int i = 0; i < ilosc_monet; i += 2)
	{
	kol2.wyjmij();
	}

	cout << "Kolekcja po kradziezy:" << endl;
	cout << kol2;
	cout << "Wartosc kolekcji: " << kol2.wartosc_kolekcji() << " zl" << endl << endl;

	system("pause");
	
	
}