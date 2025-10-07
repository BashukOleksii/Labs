#pragma once

#include "B1.h"

class D1: virtual protected B1 {

protected:
	double d1;
public:
	D1(int _b1 = 0, double _d1 = 0) : B1(_b1), d1(_d1) { cout << "Викликано конструктор похідного класу D1" << endl; }

	void Print() override {
		cout << setw(18) << d1 << " |";
	}

	void Init() override {
		cout << "Введіть значення для подвійного дійсного поля d1: ";cin >> d1;
	}


	~D1() { cout << "Викликано деструктор похідного класу D1" << endl; }

};