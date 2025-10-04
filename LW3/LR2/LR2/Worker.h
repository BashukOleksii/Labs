#pragma once

#include "Cadr.h"

class Worker: public Cadr {
private:
	int productCount;
	int discharge;
public:


	Worker(string name, int enteredYear, string education, int productCount, int discharge): Cadr(name,enteredYear,education){
		Cadr::NormalNum(productCount);
		this->productCount = productCount;
		NormalNum(discharge);
		this->discharge = discharge;
		
	}

	Worker() : productCount(0), discharge(0) {}






	void Print() override {

		Cadr::Print();
		cout << setw(13) << GetProductCount() << " |" << setw(8) << GetDischarge() << " |";
		cout << setw(15) << "|" << setw(10) << "|";
		cout << setw(15) << "|" <<endl;

		Cadr::PrintLine();
	}



	double GetSalary() override{
		
		switch (discharge)
		{
		case 1:
			return 12000; break;
		case 2:
			return 15000; break;
		case 3:
			return 17000; break;
		default:
			return 20000; break;

		}
	}

	void Work() override {
		cout << "Виконати роботу робiтника." << endl;
	}





	void Init() override{
		Cadr::Init();
		SetDischarge();
		SetProductCount();
		cin.ignore();
	}





	void SetProductCount() {
		cout << "Введiть кiлькiсть виготовлений продуктiв.";
		cin >> productCount;
		Cadr::NormalNum(productCount);
	}

	void SetDischarge() {
		cout << "Введiть розр'яд: ";
		cin >> discharge; NormalNum(discharge);
	}


	int GetProductCount() {
		return productCount;
	}

	int GetDischarge() {
		return discharge;
	}


	Worker& operator++() override {
		productCount++;
		return *this;
	}

	Worker& operator--() override {
		if (productCount > 0)
			productCount--;
		else
			cout << "Не можна пiти в мiнус" << endl;
		return *this;
	}


private:
	void NormalNum(int& num) override {

		while (num < 0 || num > 4) {
			cout << "Невiрний розряд." << endl;
			cin >> num;
		}
	}

};




