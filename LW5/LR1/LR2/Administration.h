#pragma once

#include "Cadr.h"

class Administration : public Cadr{
private:
	string position;
	int peopleCount;
public:

	Administration(string name, int enteredYear, string primatySkill, string education, string position, int peopleCount) : Cadr(name, enteredYear, primatySkill, education) {
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
		Cadr::record.ShortLine(false); cout << " Інформація про Administration "; Cadr::record.ShortLine(true);
		cout << setw(30) << "Посада" << setw(30) << GetPosition() << endl;
		cout << setw(30) << "Кількість робітників" << setw(30)<< GetPeopleCount() << endl;
		PrintFatLine(false); PrintFatLine(false); PrintFatLine(true);
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