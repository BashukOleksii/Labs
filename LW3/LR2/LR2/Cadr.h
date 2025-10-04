#pragma once

#include <iostream>
#include <string>
#include <iomanip>

using namespace std;

class List;

class Cadr {
protected:
	string name;
	int enteredYear;
	string education;
public:


	Cadr(string name, int enteredYear, string education);

	Cadr();


	void Add();

	static void Shapka();

	virtual void Print() {
		cout << setw(13) << GetName() << " |" << setw(8) << GetEnteredYear() << " |" << setw(8) << GetEducation() << " |";
	}




	virtual double GetSalary() = 0;

	virtual void Work() = 0;




	virtual void Init();





	void SetName();

	void SetEnteredYear();

	void SetEducation();




	string GetName();

	int GetEnteredYear();

	string GetEducation();

	bool CompareName(string name);

	virtual Cadr& operator++() = 0;
	virtual Cadr& operator--() = 0;

protected:
	virtual void NormalNum(int& num);

	static void PrintLine();

};

