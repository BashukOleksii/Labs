#pragma once

#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

class B1 {

public :
	

	B1() {
		cout << "Викликано конструктор класу B1" << endl;
	}

	virtual void Print() = 0;

	virtual void Init() = 0;

	static void Shapka() {
		cout  << setw(20) << "d1 |" << setw(20) << "d2 |" <<setw(20)<< "b2 |" << setw(20) << "d3 |" << setw(20) << "d4" << endl;
	}

	~B1() { cout << "Викликано деструктор класу B1" << endl; }
};