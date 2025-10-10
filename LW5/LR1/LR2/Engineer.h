#pragma once

#include "Cadr.h"

class Engineer : public Cadr{
private:
	string specialization;
	int countProject;
public:

	Engineer(string name, int enteredYear, string education, string primarySkill, string specialization, int countProject) : Cadr(name, enteredYear,primarySkill, education) {
		this->specialization = specialization;
		Cadr::NormalNum(countProject);
		this->countProject = countProject;
	}

	Engineer() : specialization("None"), countProject(0) {}







	void Work() override {
		cout << "Iнженер виконав роботу." << endl;
	}

	double GetSalary() override {
		if (countProject < 10)
			return 20000;
		else if (countProject < 30)
			return 30000;
		else
			return 50000;
	}





	void Init() override {
		Cadr::Init();

		SetSpecialization();
		SetCountProject();
		cin.ignore();
	}

	void Print() override {
		
		Cadr::Print();
		Cadr::record.ShortLine(false); cout << " Інформація про Engieer "; Cadr::record.ShortLine(true);
		cout << setw(30) << "Спеціалізація" << setw(30) << GetSpecialization() << endl;
		cout << setw(30) << "Кількість виконаних проектів"<< setw(30) << GetCountProject() << endl;
		PrintFatLine(false); PrintFatLine(false); PrintFatLine(true);
	}



	void SetCountProject() {
		cout << "Введiть кiлькiсть проeктiв: "; cin >> countProject; Cadr::NormalNum(countProject);
	}

	void SetSpecialization() {
		cout << "Введiть спецiалiзацiю: "; getline(cin, specialization);
	}

	Engineer& operator++() override {
		countProject++;
		return *this;
	}

	Engineer& operator--() override {
		if (countProject > 0)
			countProject--;
		else
			cout << "Не можна пiти в мiнус" << endl;
		
		return *this;
	}




	string GetSpecialization() {
		return specialization;
	}

	int GetCountProject() {
		return countProject;
	}

};