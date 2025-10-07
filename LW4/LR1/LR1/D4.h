#pragma once

#include "D1.h"
#include "D3.h"

class D4 : public D1, public D3 {
protected:
	char d4;
public:
	D4(double _d1 = 0, short _d2 = 0, long _b2 = 0, float _d3 = 0, char _d4 = '\0') : D1(_d1), D3(_d2, _b2, _d3), d4(_d4) { cout << "Викликано конструктор похідного класу D4" << endl; }
	

	
	void Show () override{
		D1::Show();
		D3::Show();
		cout << setw(20) << d4 << endl;
	}

	void Init() override {
		D1::Init();
		D3::Init();
		cout << "Введіть буквенне значення d4: "; cin >> d4;
	}

	~D4() { cout << "Викликано деструктор похідного класу D4" << endl; }
};