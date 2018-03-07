#pragma once
#include <iostream>
#include <list>
#include "Numizmat.h"
#include <fstream>
#include <algorithm>
#include <string>
#include <cstdlib>
#include <set>
#include <iomanip>
using namespace std;

class czy_wywalamy {
	Numizmat ile;
public:
	czy_wywalamy(Numizmat a) :ile(a) {}
	bool operator()(Numizmat  a)
	{
		return true;//((a==ile)&&(a.get_cena()<ile.get_cena()));
	}
};


const int N = 1000;
class Zbior
{
	list<Numizmat> monety;
public:
	Zbior() {};
	void wczytaj_z_pliku(const char*);
	int ile_monet();
	bool czy_pusta();
	void dodaj_do_kolekcji(Numizmat);
	void dodaj_do_kolekcji(list<Numizmat> _monety);
	Numizmat wyjmij();
	void uloz_rocznikami();
	void sprzedaj(int cena);
	int wartosc_kolekcji() ;
	list<Numizmat> przenies_duplikaty();
	friend ostream& operator<<(ostream& out, const Zbior& t);
	
};

bool porownaj(const Numizmat& k1, const Numizmat& k2)
{
	if (k1.get_opis() > k2.get_opis())
		return true;

	if ((k1.get_opis() == k2.get_opis()) &&
		(k1.get_rok() > k2.get_rok()))
		return true;

	if ((k1.get_opis() == k2.get_opis()) &&
		(k1.get_rok() == k2.get_rok()) &&
		(k1.get_cena() > k2.get_cena()))
		return true;

	return false;
}


list<Numizmat> Zbior::przenies_duplikaty()
{
	list<Numizmat> monety2;
	list<Numizmat> monety3;
	Numizmat t;

	list<Numizmat>::iterator it1 = monety.begin();
	list<Numizmat>::iterator it2 = monety.begin();

	for (; it1 != monety.end(); it1++)
	{
		t = *it1;
		for (it2 = monety.begin(); it2 != monety.end(); it2++)
		{
			if (*it1>*it2)
			{
				t = *it2;
#
				if ((*it1).get_cena() < 0)
					cout << " ";
			}
		}

		monety2.push_front(t);
		
	}

	monety2.sort(porownaj);
	monety2.unique();

	
	for (it1 = monety2.begin(); it1 != monety2.end(); it1++)
	{
		
			monety.remove(*it1);
		
	}
	monety3 = monety;
	monety = monety2;
	return monety3;

}


	
//
void Zbior::dodaj_do_kolekcji(list<Numizmat> _monety)
{
	list<Numizmat>::iterator ind = _monety.begin();

	for (;ind != _monety.end();ind++)
	{
		monety.push_front(*ind);

	}

}

void Zbior::dodaj_do_kolekcji(Numizmat t)
{
	monety.push_front(t);
}


ostream& operator<<(ostream& out, const Zbior& t)
{
	if (t.monety.empty())
	{
		out << "Pusta lista" << endl;
		return out;
	}

	list<Numizmat>::const_iterator ind =(t.monety).begin();
	for (;ind != t.monety.end();ind++)
	{
		out << *ind << endl;
	}
	
	
	return out;
}

int Zbior::wartosc_kolekcji() 
{
	int k=0;
	list<Numizmat>::iterator ind = monety.begin();
	for (;ind != monety.end();++ind)
	{
		k += (*ind).get_cena();
	}
	return k;

}


Numizmat Zbior::wyjmij()
{
	
	int j = 0;

	list<Numizmat>::iterator it = monety.begin();
	j = rand() % monety.size();
	advance(it, j);
	
	Numizmat t = *it;
	monety.erase(it);
		return t;
}

void Zbior::wczytaj_z_pliku(const char*t)
{
	string g[N];
	string wiersz;
	int z = 0;
	ifstream wej(t);
	if (!wej) {
		cout << "Brak pliku ?" << endl;
		return;
	}
	// ------------------------

	while (getline(wej, wiersz))
	{
		g[z] = wiersz;
		z++;
	}
	// ------------------------
	wej.close();

	int cenaa = 0;
	int rokk = 0;
	string opiss = " ";

	for (int i = 0;i < z;i++)
	{
		
	

		char znak = ',';
	
		int beg = 0, end;
		
			end = g[i].find(znak, beg);
			if (end == string::npos) end = g[i].size();
			opiss = g[i].substr(beg, end - beg) ;
			beg = end + 1;

			end = g[i].find(znak, beg);
			if (end == string::npos) end = g[i].size();
			rokk = stoi(g[i].substr(beg, end - beg));
			beg = end + 1;

			end = g[i].find(znak, beg);
			if (end == string::npos) end = g[i].size();
			cenaa = stoi(g[i].substr(beg, end - beg));
			beg = end + 1;

		
			Numizmat r(cenaa, rokk, opiss);



			monety.push_front(r);
	}

}

int Zbior::ile_monet()
{
	return monety.size();

}
bool Zbior::czy_pusta()
{
	return monety.size() == 0;

}

class PorownajMonety
{
	
	
	public:

		bool operator()(Numizmat &a, Numizmat &b)
		{
			

			if (a.get_rok() == b.get_rok())
				return a.get_opis() < b.get_opis();
			else
				return (a.get_rok() < b.get_rok());
		}
	
};




class Wartosciowa
{

	int limit;
public:
	Wartosciowa(int a) : limit(a) {}
	bool operator()(Numizmat &a) { return a.get_cena() > limit; }

};
void Zbior::uloz_rocznikami()
{
	PorownajMonety x;
	monety.sort(x);
}
void Zbior::sprzedaj(int cena)
{
	Wartosciowa a(cena);

	
	monety.erase(remove_if(monety.begin(), monety.end(), a), monety.end());
	
	

}
