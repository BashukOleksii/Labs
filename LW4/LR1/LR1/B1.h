#pragma once

#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

class B1 {
protected:
	int b1;
public :

	B1(int _b1): b1(_b1) {
		cout << "Викликано конструктор класу B1" << endl;
	}

	virtual void Print() {
		cout << setw(18) << b1 << " |";
	}

	virtual void Init() {
		cout << "Введіть значення для цілого b1: "; cin >> b1;
	}

	static void Shapka() {
		cout  << setw(20) << "b1 |" << setw(20) << "d1 |" << setw(20) << "d2 |" <<setw(20)<< "b2 |" << setw(20) << "d3 |" << setw(20) << "d4" << endl;
	}

	~B1() { cout << "Викликано деструктор класу B1" << endl; }
};