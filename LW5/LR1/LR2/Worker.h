#pragma once

#include "Cadr.h"

class Worker: public Cadr {
private:
	int productCount;
	int discharge;
public:


	Worker(string name, int enteredYear, string primarySkill, string education, int productCount, int discharge): Cadr(name,enteredYear,primarySkill,education){
		Cadr::NormalNum(productCount);
		this->productCount = productCount;
		NormalNum(discharge);
		this->discharge = discharge;
		
	}

	Worker() : productCount(0), discharge(0) {}

	void Print() override {

		Cadr::Print();

		Cadr::record.ShortLine(false); cout << " Інформація про Worker "; Cadr::record.ShortLine(true);
		cout << setw(30) << "Розряд" << setw(30) << GetDischarge() << endl;
		cout << setw(30) << "Кількість виконаних завдань" << setw(30) << GetProductCount() << endl;
		PrintFatLine(false); PrintFatLine(false); PrintFatLine(true);
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
		cin >> discharge; Normal(discharge);
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
	void Normal(int& num) {

		while (num < 0 || num > 4) {
			cout << "Невiрний розряд." << endl;
			cin >> num;
		}
	}

};




