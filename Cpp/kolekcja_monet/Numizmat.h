#pragma once
#include <iostream>
#include <string>
using namespace std;

class Numizmat
{
	int cena; 
	int rok;
	string opis;
public:
	Numizmat() {
		cena = 0;
		rok = 0;
		opis = " ";
	};
	Numizmat(int _numer, int _rok, string _postac)
	{
		cena = _numer;
		rok = _rok;
		opis = _postac;
	}
	const string get_opis() const
	{
		return opis;
	}
	const int get_rok() const
	{
		return rok;
	}
	const  int get_cena() const
	{
		return cena;
	}
	
	friend bool operator==(const Numizmat& k1, const Numizmat& k2);
	friend ostream& operator<<( ostream& out, const Numizmat& k);
	friend bool operator > ( const Numizmat& k1,const Numizmat& k2);
	
	
	
	
};

bool operator==(const Numizmat& k1, const Numizmat& k2)
{
	if ((k1.rok == k2.rok) && (k1.opis == k2.opis) && (k1.cena == k2.cena))
		return true;
	return false;
}

ostream& operator<<( ostream& out, const Numizmat& k)
{
	out << k.opis << " rok: " << k.rok << " cena: " << k.cena << endl;
	return out;
}

bool operator > ( const Numizmat& k1,  const Numizmat& k2)
{
	if ((k1.get_opis() == k2.get_opis()) &&
		(k1.get_cena() < k2.get_cena()) &&
		(k1.get_rok() == k2.get_rok()))
		return true;
	else
		return false;
}
