#pragma once

#include "Cadr.h"

class Engineer : public Cadr{
private:
	string specialization;
	int countProject;
public:

	Engineer(string name, int enteredYear, string education, string specialization, int countProject) : Cadr(name, enteredYear, education) {
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
		cout << setw(15) << "|" << setw(10) << "|";
		cout << setw(13) << GetSpecialization() << " |" << setw(8) << GetCountProject() << " |";
		cout << setw(15) << "|"  << endl;

		Cadr::PrintLine();
	}



	void SetCountProject() {
		cout << "¬ведiть кiлькiсть проeктiв: "; cin >> countProject; Cadr::NormalNum(countProject);
	}

	void SetSpecialization() {
		cout << "¬ведiть спецiалiзацiю: "; getline(cin, specialization);
	}

	Engineer& operator++() override {
		countProject++;
		return *this;
	}

	Engineer& operator--() override {
		if (countProject > 0)
			countProject--;
		else
			cout << "Ќе можна пiти в мiнус" << endl;
		
		return *this;
	}




	string GetSpecialization() {
		return specialization;
	}

	int GetCountProject() {
		return countProject;
	}

};