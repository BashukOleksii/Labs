#pragma once

#include "B1.h"

class D2 : virtual public B1 {
protected:
	short d2;
public:
	D2(short _d2 = 0) :  d2(_d2) {
		cout << "Викликано конструкор похідного класу D2" << endl;;
	}

	

	void Show() override {
		cout << setw(18) << d2 << " |";
	}
	
	void Init() override {
		cout << "Введіть коротке цілочсельне значення для d2: "; cin >> d2;
	}

	~D2() {
		cout << "Викликано деструктор похідного класу D2" << endl;
	}
};