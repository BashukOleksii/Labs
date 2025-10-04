#pragma once

#include "Cadr.h"

class Administration : public Cadr{
private:
	string position;
	int peopleCount;
public:

	Administration(string name, int enteredYear, string education, string position, int peopleCount) : Cadr(name, enteredYear, education) {
		this->position = position;
		Cadr::NormalNum(peopleCount);
		this->peopleCount = peopleCount;
	}

	Administration() : position("None"), peopleCount(0) {};







	void Work() override {
		cout << "Адмiнiстрацiя працює." << endl;
	}

	double GetSalary() override {
		if (peopleCount< 5)
			return 40000;
		else if (peopleCount < 25)
			return 50000;
		else
			return 70000;
	}






	void Print() override {
		Cadr::Print();
		cout << setw(15) << "|" << setw(10) << "|";
		cout << setw(15) << "|" << setw(10) << "|";
		cout << setw(13) << GetPosition() << " |" << setw(10) << GetPeopleCount() << endl;

		Cadr::PrintLine();
	}

	void Init() override {
		Cadr::Init();
		SetPosition();
		SetPeopleCount();
		cin.ignore();
	}



	void SetPosition() {
		cout << "Введiть посаду: "; getline(cin, position);
	}

	void SetPeopleCount() {
		cout << "Введiть кiлькiсть пiдданих: "; cin >> peopleCount; Cadr::NormalNum(peopleCount);
	}




	string GetPosition() {
		return position;
	}

	int GetPeopleCount() {
		return peopleCount;
	}

	
	Administration& operator++() override {
		peopleCount++;
		return *this;
	}

	Administration& operator--() override {
		if (peopleCount > 0)
			peopleCount--;
		else
			cout << "Не можна пiти в мiнус" << endl;
		return *this;
	}

};