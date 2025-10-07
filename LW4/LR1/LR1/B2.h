#pragma once

#include <iostream>
#include <iomanip>

using namespace std;

class B2 {
protected:
	long b2;
public:
	B2(long _b2 = 0) : b2(_b2) { cout << "Викликано конструктор базового класу B2" << endl; }

	virtual void abstractMethod2() = 0;

	virtual void Print() {
		cout << setw(18) << b2 << " |";
	}

	virtual void Init() {
		cout << "Введіть довге число b2 "; cin >> b2;
	}


	~B2() { cout << "Викликано деструктор базового класу B2" << endl; }

};