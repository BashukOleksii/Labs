#pragma once

#include "B2.h"
#include "D2.h"

class D3 : protected D2, protected B2 {
protected:
	float d3;
public:

	D3(int _b1 = 0, short _d2 =0, long _b2 =0, float _d3 = 0) : B1(_b1), D2(_b1,_d2), B2(_b2), d3(_d3) {
		cout << "Викликано конструктор похідного класу D3" << endl;
	}

	void Print()override {
		D2::Print();
		B2::Print();
		cout << setw(18) << d3 << " |";
	}

	void Init() override {
		D2::Init();
		B2::Init();
		cout << "Введіть дійсне значення поля d3: "; cin >> d3;
	}

	~D3() {
		cout << "Викликано деструктор похідного класу D3" << endl;
	}
};
